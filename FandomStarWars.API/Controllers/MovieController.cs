using FandomStarWars.Application.CQRS.BaseResponses;
using FandomStarWars.Application.DTO_s;
using FandomStarWars.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
//using Refit;

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
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetMovies()
        {
            GenericResponse response = _movieService.GetAllAsync().Result;
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("{id}")]
        public async Task<ActionResult<MovieDTO>> GetById(int id)
        {
            var response = _movieService.GetByIdAsync(id).Result;
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Title/{title}")]
        public async Task<ActionResult<MovieDTO>> GetByTitle(string title)
        {
            var response = _movieService.GetByNameAsync(title).Result;
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<MovieDTO>> Create(MovieDTO movie) 
        {
            var response = _movieService.CreateAsync(movie).Result;
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<MovieDTO>> Update(MovieDTO movie)
        {
            var response = _movieService.UpdateAsync(movie).Result;
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        [Authorize]
        [Route("{id}")]
        public async Task<ActionResult<MovieDTO>> Delete(int id)
        {
            var response = _movieService.DeleteAsync(id).Result;
            return response.IsSuccessful ? Ok(response) : BadRequest(response); 
        }
    }
}
