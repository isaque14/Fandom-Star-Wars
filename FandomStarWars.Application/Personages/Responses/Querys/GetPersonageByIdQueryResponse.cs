using FandomStarWars.Application.DTO_s;
using FandomStarWars.Application.Personages.Responses.Base;
using FandomStarWars.Domain.Entities;

namespace FandomStarWars.Application.Personages.Responses.Querys
{
    public class GetPersonageByIdQueryResponse : BaseResponse
    {
        public PersonageDTO PersonageDTO { get; set; }
    }
}
