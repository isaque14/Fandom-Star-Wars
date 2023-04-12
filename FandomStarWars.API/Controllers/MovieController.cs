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
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private const int IdLastMovieOrigin = 6;


        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        /// <summary>
        /// Obter todos os Filmes 
        /// </summary>
        /// <returns>Coleção de Filmes</returns>
        /// <response code="200">Sucesso</response>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetMovies()
        {
            GenericResponse response = _movieService.GetAllAsync().Result;
            return Ok(response);
        }

        /// <summary>
        /// Obter Filme pelo Id
        /// </summary>
        /// <param name="id">Identificador do Filme</param>
        /// <returns>Dados do Filme</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não Encontrado</response>
        [HttpGet]
        [AllowAnonymous]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MovieDTO>> GetById(int id)
        {
            var response = _movieService.GetByIdAsync(id).Result;
            return response.IsSuccessful ? Ok(response) : NotFound(response);
        }

        /// <summary>
        /// Obter Filme pelo Título
        /// </summary>
        /// <param name="name">Título do Filme</param>
        /// <returns>Dados do Filme</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não Encontrado</response>
        [HttpGet]
        [AllowAnonymous]
        [Route("Title/{title}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MovieDTO>> GetByTitle(string title)
        {
            var response = _movieService.GetByNameAsync(title).Result;
            return response.IsSuccessful ? Ok(response) : NotFound(response);
        }

        /// <summary>
        /// Cadastrar Filme
        /// </summary>
        /// <param name="personageDTO">Dados do Filme</param>
        /// <returns>Objeto Filme Criado</returns>
        /// <response code="201">Sucesso</response>
        /// <response code="400">Falha</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MovieDTO>> Create(MovieDTO movie) 
        {
            var response = _movieService.CreateAsync(movie).Result;
            return response.IsSuccessful ? StatusCode(201, response) : BadRequest(response);
        }

        /// <summary>
        /// Atualizar um Filme
        /// </summary>
        /// <param name="movie">Dados do Filme</param>
        /// <returns>Filme Atualizado</returns>
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
        public async Task<ActionResult<MovieDTO>> Update(MovieDTO movie)
        {
            var role = HttpContext.User.FindFirstValue(ClaimTypes.Role);

            if (movie.Id <= IdLastMovieOrigin && role is not "Admin")
            {
                return StatusCode(403, new GenericResponse
                {
                    IsSuccessful = false,
                    Message = "Ops, parece que você não tem permissão de alterar este filme, confira se possua uma conta Admin"
                });
            }

            var response = _movieService.UpdateAsync(movie).Result;
            return response.IsSuccessful ? Ok(response) : NotFound(response);
        }

        /// <summary>
        /// Deletar um Filme
        /// </summary>
        /// <param name="id">Identificador do Filme</param>
        /// <returns>Objeto Filme excluído</returns>
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
        [Route("{id}")]
        public async Task<ActionResult<MovieDTO>> Delete(int id)
        {
            var role = HttpContext.User.FindFirstValue(ClaimTypes.Role);

            if (id <= IdLastMovieOrigin && role is not "Admin")
            {
                return StatusCode(403, new GenericResponse
                {
                    IsSuccessful = false,
                    Message = "Ops, parece que você não tem permissão de deletar este filme, confira se possua uma conta Admin"
                });
            }

            var response = _movieService.DeleteAsync(id).Result;
            return response.IsSuccessful ? Ok(response) : NotFound(response); 
        }
    }
}
