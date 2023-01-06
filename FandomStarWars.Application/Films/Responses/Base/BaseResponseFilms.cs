namespace FandomStarWars.Application.Films.Responses.Base
{
    public abstract class BaseResponseFilms
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
    }
}
