using FandomStarWars.Application.DTO_s;
using FandomStarWars.Application.Personages.Responses.Base;

namespace FandomStarWars.Application.Personages.Responses.Querys
{
    public class GetPersonageByNameQueryResponse : BaseResponse 
    {
        public PersonageDTO PersonageDTO { get; set; }
    }
}
