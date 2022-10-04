using FandomStarWars.Domain.Entities.Base;

namespace FandomStarWars.Domain.Entities
{
    public class Character : Entity
    {
        public Character(string name, string height, string mass, string hair_color, string skin_color, 
            string eye_color, string birth_year, string gender, string homeworld, List<string> films, 
            List<string> species, List<string> vehicles, List<string> starships, DateTime created, DateTime edited, string url)
        {
            Name = name;
            Height = height;
            Mass = mass;
            Hair_color = hair_color;
            Skin_color = skin_color;
            Eye_color = eye_color;
            Birth_year = birth_year;
            Gender = gender;
            Homeworld = homeworld;
            Films = films;
            Species = species;
            Vehicles = vehicles;
            Starships = starships;
            Created = created;
            Edited = edited;
            Url = url;
        }

        public string Name { get; private set; }
        public string Height { get; private set; }
        public string Mass { get; private set; }
        public string Hair_color { get; private set; }
        public string Skin_color { get; private set; }
        public string Eye_color { get; private set; }
        public string Birth_year { get; private set; }
        public string Gender { get; private set; }
        public string Homeworld { get; private set; }
        public List<string> Films { get; private set; }
        public List<string> Species { get; private set; }
        public List<string> Vehicles { get; private set; }
        public List<string> Starships { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime Edited { get; private set; }
        public string Url { get; private set; }
    }
}

