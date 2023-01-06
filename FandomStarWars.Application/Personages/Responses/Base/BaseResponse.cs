namespace FandomStarWars.Application.Personages.Responses.Base
{
    public abstract class BaseResponse
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public Object Object { get; set; }
    }
}
