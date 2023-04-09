using FandomStarWars.Application.CQRS.BaseResponses;
using FandomStarWars.Application.DTO_s;
using FandomStarWars.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FandomStarWars.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
 
    public class PersonageController : ControllerBase
    {
        private readonly IPersonageService _personageService;
        private const int IdLastPersonageOrigin = 86;

        public PersonageController(IPersonageService personageService)
        {
            _personageService = personageService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<PersonageDTO>>> Get()
        {
            var response = await _personageService.GetAllAsync();
            if (response is null)
                return NotFound("Personages not found");

            return Ok(response);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Name/{name}")]
        public async Task<ActionResult<PersonageDTO>> GetPersonageByName(string name)
        {
            var response = await _personageService.GetByNameAsync(name);

            if (response is null)
                return NotFound("Personage not found");

            return Ok(response);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("{id}")]
        public async Task<ActionResult<PersonageDTO>> GetPersonageById(int id)
        {
            var response = await _personageService.GetByIdAsync(id);

            if (response is null)
                return NotFound("Personage not found");

            return Ok(response);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<PersonageDTO>> CreatePersonage(PersonageDTO personageDTO)
        {
            var response = await _personageService.CreateAsync(personageDTO);
            return Ok(response);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<PersonageDTO>> UpdatePersonage(int id, [FromBody] PersonageDTO personageDTO)
        {
            if (id != personageDTO.Id || personageDTO is null)
                return BadRequest("Data Invalid");

            var role = HttpContext.User.FindFirstValue(ClaimTypes.Role);

            if (id <= IdLastPersonageOrigin && role is not "Admin")
            {
                return StatusCode(403, new GenericResponse
                {
                    IsSuccessful = false,
                    Message = "Ops, parece que você não tem permissão de alterar este personagem, confira se possua uma conta Admin"
                });
            }

            var response = await _personageService.UpdateAsync(personageDTO);
            return Ok(response);
        }

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<PersonageDTO>> Delete(int id)
        {
            var role = HttpContext.User.FindFirstValue(ClaimTypes.Role);

            //if (id <= IdLastPersonageOrigin && role is not "ADMIN")
            {
                return StatusCode(403, new GenericResponse
                {
                    IsSuccessful = false,
                    Message = "Ops, parece que você não tem permissão de deletar este personagem, confira se possua uma conta Admin"
                });
            }
            var response =  await _personageService.DeleteAsync(id);
            return Ok(response);
        }
    }
}
