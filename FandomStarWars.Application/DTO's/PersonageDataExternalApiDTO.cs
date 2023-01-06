namespace FandomStarWars.Application.DTO_s
{
    public class PersonageDataExternalApiDTO
    {
        public string Name { get; set; }
        public string Height { get; set; }
        public string Mass { get; set; }
        public string Hair_Color { get; set; }
        public string Skin_Color { get; set; }
        public string Eye_Color { get; set; }
        public string Birth_Year { get; set; }
        public string Gender { get; set; }
        public string Homeworld { get; set; }
        public List<string> Films { get; set; }
        public List<string> Species { get; set; }
        public List<string> Vehicles { get; set; }
        public List<string> Starships { get; set; }
        public string Created { get; set; }
        public string Edited { get; set; }
        public string Url { get; set; }

        public class Root
        {
            public int Count { get; set; }
            public string Next { get; set; }
            public string Previous { get; set; }
            public List<PersonageDataExternalApiDTO> Results { get; set; }
        }
    }
}
