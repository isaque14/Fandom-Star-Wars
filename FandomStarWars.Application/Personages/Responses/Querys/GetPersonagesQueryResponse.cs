using FandomStarWars.Application.DTO_s;
using FandomStarWars.Application.Personages.Responses.Base;

namespace FandomStarWars.Application.Personages.Responses.Querys
{
    public class GetPersonagesQueryResponse : BaseResponse
    {
        public IEnumerable<PersonageDTO> PersonagesDTO { get; set; }
    }
}
