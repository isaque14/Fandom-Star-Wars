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
        private const int IdLastPersonageOrigin = 82;

        public PersonageController(IPersonageService personageService)
        {
            _personageService = personageService;
        }

        /// <summary>
        /// Obter todos os Personagens 
        /// </summary>
        /// <returns>Coleção de Personagens</returns>
        /// <response code="200">Sucesso</response>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PersonageDTO>>> Get()
        {
            var response = await _personageService.GetAllAsync();
            return Ok(response);
        }

        /// <summary>
        /// Obter Personagem pelo nome
        /// </summary>
        /// <param name="name">Nome do personagem</param>
        /// <returns>Dados do personagem</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não Encontrado</response>
        [HttpGet]
        [AllowAnonymous]
        [Route("Name/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonageDTO>> GetPersonageByName(string name)
        {
            var response = await _personageService.GetByNameAsync(name);

            if (response is null)
                return NotFound("Personage not found");

            return Ok(response);
        }

        /// <summary>
        /// Obter personagem pelo Id
        /// </summary>
        /// <param name="id">Identificador do personagem</param>
        /// <returns>Dados do personagem</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não Encontrado</response>
        [HttpGet]
        [AllowAnonymous]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonageDTO>> GetPersonageById(int id)
        {
            var response = await _personageService.GetByIdAsync(id);

            if (response is null)
                return NotFound("Personage not found");

            return Ok(response);
        }

        /// <summary>
        /// Cadastrar Personagem
        /// </summary>
        /// <param name="personageDTO">Dados do Personagem</param>
        /// <returns>Objeto Personagem Criado</returns>
        /// <response code="201">Sucesso</response>
        /// <response code="400">Falha</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<PersonageDTO>> CreatePersonage(PersonageDTO personageDTO)
        {
            var response = await _personageService.CreateAsync(personageDTO);
            return Ok(response);
        }

        /// <summary>
        /// Atualizar um Personagem
        /// </summary>
        /// <param name="id">Identificador do Personagem</param>
        /// <param name="personageDTO">Dados do Personagem</param>
        /// <returns>Personagem Atualizado</returns>
        /// <response code="404">Não Encontrado</response>
        /// <response code="200">Sucesso</response>
        /// <response code="403">Credencias não autorizadas</response>
        /// <response code="401">Não Autorizado</response>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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

        /// <summary>
        /// Deletar um Personagem
        /// </summary>
        /// <param name="id">Identificador do Personagem</param>
        /// <returns>Objeto Personagem excluído</returns>
        /// <response code="404">Não Encontrado</response>
        /// <response code="200">Sucesso</response>
        /// <response code="403">Credencias não autorizadas</response>
        /// <response code="401">Não Autorizado</response>
        [HttpDelete]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<PersonageDTO>> Delete(int id)
        {
            var role = HttpContext.User.FindFirstValue(ClaimTypes.Role);

            if (id <= IdLastPersonageOrigin && role is not "Admin")
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
