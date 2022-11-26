using AutoMapper;
using FandomStarWars.Application.DTO_s;
using FandomStarWars.Application.Films.Commands;
using FandomStarWars.Domain.Entities;
using FandomStarWars.Domain.Interfaces;
using MediatR;

namespace FandomStarWars.Application.Films.Handlers
{
    public class CreateFilmCommandHandler : IRequestHandler<CreateFilmCommand, Film>
    {
        private readonly IFilmRepository _filmRepository;
        private readonly IMapper _mapper;

        public CreateFilmCommandHandler(IFilmRepository filmRepository, IMapper mapper)
        {
            _filmRepository = filmRepository;
            _mapper = mapper;
        }

        public async Task<Film> Handle(CreateFilmCommand request, CancellationToken cancellationToken)
        {
            var personagesEntity = new List<Personage>();
            try
            {
                if (request.Personages == null)
                {
                    throw new Exception("Personagens vazios");
                }

                foreach (var personage in request.Personages)
                {
                    personagesEntity.Add(_mapper.Map<Personage>(personage));
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            var film = new Film(
                    request.Title,
                    request.EpisodeId,
                    request.OpeningCrawl,
                    request.Director,
                    request.Producer,
                    request.ReleaseDate,
                    personagesEntity
                    );

            if (film == null)
                throw new ApplicationException($"Error creating Personage");

            var result = await _filmRepository.CreateAsync(film);
            return result;
        }
    }
}
