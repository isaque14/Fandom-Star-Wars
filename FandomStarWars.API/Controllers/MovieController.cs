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
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult> InsertFilmsApiIntoDataBase()
        {
            await _movieService.InsertFilmsExternalApiIntoDataBase();
            return Ok("Films Createds");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetMovies()
        {
                GenericResponse response = _movieService.GetAllAsync().Result;
                return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<MovieDTO>> GetById(int id)
        {
            var response = _movieService.GetByIdAsync(id).Result;
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
        [HttpGet]
        [Route("Title/{title}")]
        public async Task<ActionResult<MovieDTO>> GetByTitle(string title)
        {
            var response = _movieService.GetByNameAsync(title).Result;
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<ActionResult<MovieDTO>> Create(MovieDTO movie) 
        {
            var response = _movieService.CreateAsync(movie).Result;
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<ActionResult<MovieDTO>> Update(MovieDTO movie)
        {
            var response = _movieService.UpdateAsync(movie).Result;
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<MovieDTO>> Delete(int id)
        {
            var response = _movieService.DeleteAsync(id).Result;
            return response.IsSuccessful ? Ok(response) : BadRequest(response); 
        }
    }
}
