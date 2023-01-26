﻿using FandomStarWars.Application.CQRS.BaseResponses;
using FandomStarWars.Application.DTO_s;
using FandomStarWars.Application.Interfaces;
using FandomStarWars.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FandomStarWars.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMockRepository _mockRepository;
        
        public MovieController(IMovieService movieService, IMockRepository mockRepository)
        {
            _movieService = movieService;
            _mockRepository = mockRepository;
          
        }
        
        [HttpGet]
        [Route("insertFilms")]
        public async Task<ActionResult> InsertFilmsApiIntoDataBase()
        {
            await _movieService.InsertFilmsExternalApiIntoDataBase();
            return Ok("Films Createds");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDTO>>>  GetMovies()
        {
                GenericResponse response = _movieService.GetAllAsync().Result;
                return Ok(response);
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
