using FandomStarWars.Application.CQRS.BaseResponses;
using FandomStarWars.Application.DTO_s;
using FandomStarWars.Application.Interfaces;
using FandomStarWars.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FandomStarWars.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        
        [HttpGet]
        [Route("insertFilms")]
        public async Task<ActionResult> InsertFilmsApiIntoDataBase()
        {
            await _movieService.InsertFilmsExternalApiIntoDataBase();
            return Ok("Films Createds");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetMovies()
        {
                GenericResponse response = _movieService.GetAllAsync().Result;
                return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<MovieDTO>> GetById(int id)
        {
            var response = _movieService.GetByIdAsync(id).Result;
            return response.IsSuccessful ? Ok(response) : BadRequest(response); 
        } 
    }
}
