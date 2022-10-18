namespace FandomStarWars.Application.DTO_s
{
    public class FilmsDataExternalApiDTO
    {
        public string Title { get; set; }
        public int Episode_Id { get; set; }
        public string Opening_Crawl { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public string Release_Date { get; set; }
        public List<string> Characters { get; set; }
        public List<string> Planets { get; set; }
        public List<string> Starships { get; set; }
        public List<string> Vehicles { get; set; }
        public List<string> Species { get; set; }
        public string Created { get; set; }
        public string Edited { get; set; }
        public string Url { get; set; }

        public class RootFilms
        {
            public int Count { get; set; }
            public object Next { get; set; }
            public object Previous { get; set; }
            public List<FilmsDataExternalApiDTO> Results { get; set; }
        }
    }
}
