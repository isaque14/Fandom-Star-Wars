using FandomStarWars.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FandomStarWars.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalApiController : ControllerBase
    {
        private readonly IApiClientService _apiClientService;

        public ExternalApiController(IApiClientService apiClientService)
        {
            _apiClientService = apiClientService;
        }

        [HttpPost]
        [Route("insertPersonages")]
        [Authorize]
        //[ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult> InsertPersonagesApiIntoDataBase()
        {
            await _apiClientService.InsertPersonagesExternalApiIntoDataBase();
            return Ok("insert into database finish");
        }

        [HttpGet]
        [Authorize]
        [Route("insertFilms")]
        //[ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult> InsertFilmsApiIntoDataBase()
        {
            await _apiClientService.InsertFilmsExternalApiIntoDataBase();
            return Ok("Films Createds");
        }
    }
}
