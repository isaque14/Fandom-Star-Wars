namespace FandomStarWars.Application.CQRS.BaseResponses
{
    public abstract class BaseResponse
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public object Object { get; set; }
    }
}
