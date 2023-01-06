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
            if (personages is null)
                return NotFound("Personages not found");

            return Ok(personages);
        }

        [HttpGet]
        [Route("getname{name}")]
        public async Task<ActionResult<PersonageDTO>> GetPersonageByName(string name)
        {
            var personage = await _personageService.GetByNameAsync(name);

            if (personage is null)
                return NotFound("Personage not found");

            return Ok(personage);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<PersonageDTO>> GetPersonageById(int id)
        {
            var personage = await _personageService.GetByIdAsync(id);

            if (personage is null)
                return NotFound("Personage not found");

            return Ok(personage);
        }

        [HttpPost]
        public async Task<ActionResult<PersonageDTO>> CreatePersonage(PersonageDTO personageDTO)
        {
            await _personageService.CreateAsync(personageDTO);
            return Ok(personageDTO);
        }

        [HttpPut]
        public async Task<ActionResult<PersonageDTO>> UpdatePersonage(int id, [FromBody] PersonageDTO personageDTO)
        {
            if (id != personageDTO.Id || personageDTO is null)
                return BadRequest("Data Invalid");

           var response = await _personageService.UpdateAsync(personageDTO);
            return Ok(response);
        }
    }
}
