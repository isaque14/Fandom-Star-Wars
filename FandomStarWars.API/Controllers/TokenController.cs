﻿using FandomStarWars.API.Models;
using FandomStarWars.Application.CQRS.BaseResponses;
using FandomStarWars.Application.DTO_s;
using FandomStarWars.Application.Interfaces;
using FandomStarWars.Domain.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FandomStarWars.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticate _authentication;
        private readonly IConfiguration _configuration;
        private readonly ISendEmailService _sendEmailService;

        public TokenController(IAuthenticate authentication, IConfiguration configuration, ISendEmailService sendEmailService)
        {
            _authentication = authentication;
            _configuration = configuration;
            _sendEmailService = sendEmailService;
        }

        [HttpPost("LoginUser")]
        public async Task<ActionResult<UserToken>> Login([FromBody] LoginUserModel userInfo)
        {
            var result = await _authentication.Authenticate(userInfo.Email, userInfo.Password);

            if (result)
                return GenerateToken(userInfo);

            else
            {
                ModelState.AddModelError(string.Empty, "Invalid Login attempt.");
                return BadRequest(ModelState);
            }
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult> CreateUser([FromBody] LoginUserModel userInfo)
        {
            try
            {
                var result = await _authentication.RegisterUser(userInfo.Email, userInfo.Password);

                if (result)
                {
                    var content = "Olá, Seja muito bem vindo à Fandom-Star-Wars-API, e não se esqueça, não toleraremos quem vá para o lado escuro da força";
                    var subject = "Conta criada na Fandom-Star-Wars-API";

                    await _sendEmailService.SendEmail(userInfo.Email, subject, content);

                    return Ok(new GenericResponse
                    {
                        IsSuccessful = true,
                        Message = $"Usuário {userInfo.Email} criado com Sucesso, verifique sua conta de E-mail"
                    });
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login attempt.");
                    return BadRequest(new GenericResponse
                    {
                        IsSuccessful = false,
                        Message = "Ops, Erro ao criar conta"
                    });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new GenericResponse
                {
                    IsSuccessful = false,
                    Message = "Ops, Erro ao criar conta",
                    Object = e.Message
                });
            }

            
        }

        private UserToken GenerateToken(LoginUserModel userInfo)
        {
            //declarações do usuário
            var claims = new[]
            {
                new Claim("email", userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            //gerar chave privada para assinar o token
            var privateKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));

            //gerar a assinatura digital
            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

            //definir o tempo de expiração
            var expiration = DateTime.UtcNow.AddMinutes(10);

            //gerar o token
            JwtSecurityToken token = new JwtSecurityToken(
                //emissor
                issuer: _configuration["JWT:Issuer"],
                //audiencia
                audience: _configuration["JWT:Audience"],
                //claims
                claims: claims,
                //data de expiracao
                expires: expiration,
                //assinatura digital
                signingCredentials: credentials
                );

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}
