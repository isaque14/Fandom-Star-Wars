using FandomStarWars.Application.ExternalApi.Querys;
using FandomStarWars.Application.Interfaces;
using FandomStarWars.Application.Interfaces.APIClient;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FandomStarWars.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IFilmService _filmService;
        private readonly IExternalApiService _externalApiService;
        private readonly IMediator _mediator;

        public FilmController(IFilmService filmService, IExternalApiService externalApiService, IMediator mediator)
        {
            _filmService = filmService;
            _externalApiService = externalApiService;
            _mediator = mediator;
        }
        
        [HttpGet]
        [Route("testeFilmes")]
        public async Task<ActionResult> testeFilmes()
        {
            var filmsDTO = await _filmService.GetAllFilmsInExternalApiAsync();
            return Ok(filmsDTO);

            //var getFilms = new GetFilmsExternalApiByPageQuery(1);

            //if (getFilms == null)
            //    throw new Exception($"API could not be loaded.");

            //return Ok(await _mediator.Send(getFilms));

        }
    }
}
