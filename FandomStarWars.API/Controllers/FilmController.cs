using FandomStarWars.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FandomStarWars.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IFilmService _filmService;

        public FilmController(IFilmService filmService)
        {
            _filmService = filmService;
        }
        
        [HttpGet]
        [Route("insertFilms")]
        public async Task<ActionResult> InsertFilmsApiIntoDataBase()
        {
            await _filmService.InsertFilmsExternalApiIntoDataBase();
            return Ok("Films Createds");
        }
    }
}
