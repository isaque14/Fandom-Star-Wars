using FandomStarWars.Domain.Entities.Base;

namespace FandomStarWars.Domain.Entities
{
    public sealed class Personage : Entity
    {
        public string Name { get; private set; }
        public string Height { get; private set; }
        public string Mass { get; private set; }
        public string HairColor { get; private set; }
        public string SkinColor { get; private set; }
        public string EyeColor { get; private set; }
        public string BirthYear { get; private set; }
        public string Gender { get; private set; }
        public string Homeworld { get; private set; }
        public string Created { get; private set; }
        public string? Edited { get; private set; }
        public ICollection<Movie> Movies { get; set; }

        public Personage(
            int id, 
            string name, 
            string height, 
            string mass, 
            string hairColor, 
            string skinColor, 
            string eyeColor, 
            string birthYear, 
            string gender,
            string homeworld)
        {
            Id = id;
            Name = name;
            Height = height;
            Mass = mass;
            HairColor = hairColor;
            SkinColor = skinColor;
            EyeColor = eyeColor;
            BirthYear = birthYear;
            Gender = gender;
            Homeworld = homeworld;
            Created = DateTime.Now.ToString();
        }

        public Personage(string name, string height, string mass, string hairColor, string skinColor, string eyeColor, string birthYear, string gender,
            string homeworld)
        {
            Name = name;
            Height = height;
            Mass = mass;
            HairColor = hairColor;
            SkinColor = skinColor;
            EyeColor = eyeColor;
            BirthYear = birthYear;
            Gender = gender;
            Homeworld = homeworld;
            Created = DateTime.Now.ToString();
        }

        public void Update(string name, string height, string mass, string hairColor, string skinColor, string eyeColor, string birthYear, string gender,
            string homeworld)
        {
            Name = name;
            Height = height;
            Mass = mass;
            HairColor = hairColor;
            SkinColor = skinColor;
            EyeColor = eyeColor;
            BirthYear = birthYear;
            Gender = gender;
            Homeworld = homeworld;
            Edited = DateTime.Now.ToString();
        }
    }
}
