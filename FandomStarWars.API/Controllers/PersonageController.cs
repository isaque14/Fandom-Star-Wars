using FandomStarWars.Application.DTO_s;
using FandomStarWars.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FandomStarWars.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonageController : ControllerBase
    {
        private readonly IPersonageService _personageService;
        private readonly IFilmService _filmService;

        public PersonageController(IPersonageService personageService, IFilmService filmService)
        {
            _personageService = personageService;
            _filmService = filmService;
        }

        [HttpPost]
        [Route("insertIntoDataBase")]
        public async Task<ActionResult> InsertPersonagesApiIntoDataBase()
        {
            await _personageService.InsertPersonagesExternalApiIntoDataBase();
            return Ok("insert into database finish");
        }

        /*[HttpGet]
        [Route("testeFilmes")]
        public async Task<ActionResult> testeFilmes()
        {
            var filmsDTO = await _filmService.GetAllFilmsInExternalApiAsync();
            return Ok(filmsDTO);

        }*/

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonageDTO>>> Get()
        {
            var personages = await _personageService.GetAllAsync();



            if (personages == null)
                return NotFound("Personages not found");

            return Ok(personages);
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<ActionResult<PersonageDTO>> GetPersonageByName(string name)
        {
            var personages = await _personageService.GetByNameAsync(name);

            if (personages == null)
                return NotFound("Personages not found");

            return Ok(personages);
        }
    }
}
