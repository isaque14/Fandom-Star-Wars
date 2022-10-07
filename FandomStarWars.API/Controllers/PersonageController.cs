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

        public PersonageController(IPersonageService personageService)
        {
            _personageService = personageService;
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
            var personages = await _personageService.GetAllAsync();

            if (personages == null)
                return NotFound("Personages not found");

            return Ok(personages);
        }
    }
}
