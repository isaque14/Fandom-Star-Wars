using FandomStarWars.Application.Interfaces;
using FandomStarWars.Domain.Interfaces;

namespace FandomStarWars.Application.Services
{
    public class SeedDataBankService : ISeedDataBankService
    {
        private readonly IStatusTableRepository _statusTableRepository;
        private readonly IApiClientService _apiClientService;

        public SeedDataBankService(IStatusTableRepository statusTableRepository, IApiClientService apiClientService)
        {
            _statusTableRepository = statusTableRepository;
            _apiClientService = apiClientService;
        }

        public async Task InsertData()
        {
            try
            {
                var movieTableIsEmpty = _statusTableRepository.TableIsEmpty();
            
                if (movieTableIsEmpty)
                {
                    await _apiClientService.InsertPersonagesExternalApiIntoDataBase();
                    await _apiClientService.InsertFilmsExternalApiIntoDataBase();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }
    }
}
