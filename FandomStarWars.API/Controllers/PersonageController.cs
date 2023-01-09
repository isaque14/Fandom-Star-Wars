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
        private readonly IMovieService _filmService;

        public PersonageController(IPersonageService personageService, IMovieService filmService)
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonageDTO>>> Get()
        {
            var response = await _personageService.GetAllAsync();
            if (response is null)
                return NotFound("Personages not found");

            return Ok(response);
        }

        [HttpGet]
        [Route("getname{name}")]
        public async Task<ActionResult<PersonageDTO>> GetPersonageByName(string name)
        {
            var response = await _personageService.GetByNameAsync(name);

            if (response is null)
                return NotFound("Personage not found");

            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<PersonageDTO>> GetPersonageById(int id)
        {
            var response = await _personageService.GetByIdAsync(id);

            if (response is null)
                return NotFound("Personage not found");

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<PersonageDTO>> CreatePersonage(PersonageDTO personageDTO)
        {
            var response = await _personageService.CreateAsync(personageDTO);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<PersonageDTO>> UpdatePersonage(int id, [FromBody] PersonageDTO personageDTO)
        {
            if (id != personageDTO.Id || personageDTO is null)
                return BadRequest("Data Invalid");

           var response = await _personageService.UpdateAsync(personageDTO);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult<PersonageDTO>> Delete(int id)
        {
            var response =  await _personageService.DeleteAsync(id);
            return Ok(response);
        }
    }
}
