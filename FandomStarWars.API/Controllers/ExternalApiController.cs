using FandomStarWars.Application.Interfaces.APIClient;
using FandomStarWars.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FandomStarWars.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalApiController : ControllerBase
    {
        private readonly IExternalApiService _apiClientRepository;

        public ExternalApiController(IExternalApiService apiClientRepository)
        {
            _apiClientRepository = apiClientRepository;
        }

        //[HttpGet]
        //public async Task<ActionResult> InsertDataIntoDataBase()
        //{
        //    var result = await _apiClientRepository.GetAllPersonsAsync().ConfigureAwait(false);

        //    if (result is null)
        //        return NotFound("Data not foud");

        //    Console.WriteLine(result.Next);

        //    var characters = new List<PersonageDataExternalApi>();

        //    //foreach (var character in result.Results)
        //    //{
        //    //    var actual = new Character(character.Name, character.Height)
        //    //}

        //    return Ok(result.Results);
        //}

        //[HttpGet]
        //[Route("{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    var person = await _apiClientRepository.GetById(id);

        //    if (person == null)
        //        return BadRequest();

        //    return Ok(person);
        //}
    }
}
