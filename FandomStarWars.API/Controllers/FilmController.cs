using FandomStarWars.Application.Interfaces;
using FandomStarWars.Domain.Interfaces;
using FandomStarWars.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace FandomStarWars.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IFilmService _filmService;
        private readonly IMockRepository _mockRepository;
        

        public FilmController(IFilmService filmService, IMockRepository mockRepository)
        {
            _filmService = filmService;
            _mockRepository = mockRepository;
          
        }
        
        [HttpGet]
        [Route("insertFilms")]
        public async Task<ActionResult> InsertFilmsApiIntoDataBase()
        {
            await _filmService.InsertFilmsExternalApiIntoDataBase();
            return Ok("Films Createds");
        }


        [HttpGet]
        [Route("testeMuitos")]
        public async Task<ActionResult> Teste()
        {
            await _mockRepository.SeedBank();
            return Ok("Status finish");
        }
    }
}
