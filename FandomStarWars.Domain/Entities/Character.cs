using FandomStarWars.Domain.Entities.Base;
using FandomStarWars.Domain.Validation;

namespace FandomStarWars.Domain.Entities
{
    public sealed class Character : Entity
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
        public List<string> Films { get; private set; }
        public List<string> Species { get; private set; }
        public List<string> Vehicles { get; private set; }
        public List<string> Starships { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime Edited { get; private set; }

        public Character(int id, string name, string height, string mass, string hairColor, string skinColor, string eyeColor, string birthYear, string gender,
            string homeworld, List<string> films, List<string> species, List<string> vehicles, List<string> starships, DateTime created, DateTime edited)
        {
            DomainExceptionValidation.When(id >= 0, "Invalid Id");
            ValidationDomain(name, height, mass, hairColor, skinColor, eyeColor, birthYear, gender, homeworld);
            Films = films;
            Species = species;
            Vehicles = vehicles;
            Starships = starships;
            Created = created;
            Edited = edited;
        }

        public void Update(string name, string height, string mass, string hairColor, string skinColor, string eyeColor, string birthYear, string gender,
            string homeworld, List<string> films, List<string> species, List<string> vehicles, List<string> starships, DateTime created, DateTime edited)
        {
            ValidationDomain(name, height, mass, hairColor, skinColor, eyeColor, birthYear, gender, homeworld);
            Films = films;
            Species = species;
            Vehicles = vehicles;
            Starships = starships;
            Created = created;
            Edited = edited;
        }

        public void ValidationDomain(string name, string height, string mass, string hairColor, string skinColor,
            string eyeColor, string birthYear, string gender, string homeworld)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name is Required");
            DomainExceptionValidation.When(string.IsNullOrEmpty(height), "Height is Required");
            DomainExceptionValidation.When(string.IsNullOrEmpty(mass), "Mass is Required");
            DomainExceptionValidation.When(string.IsNullOrEmpty(hairColor), "HairColor is Required");
            DomainExceptionValidation.When(string.IsNullOrEmpty(skinColor), "skinColor is Required");
            DomainExceptionValidation.When(string.IsNullOrEmpty(eyeColor), "eyeColor is Required");
            DomainExceptionValidation.When(string.IsNullOrEmpty(birthYear), "birthYear is Required");
            DomainExceptionValidation.When(string.IsNullOrEmpty(gender), "gender is Required");
            DomainExceptionValidation.When(string.IsNullOrEmpty(homeworld), "homeworld is Required");

            Name = name;
            Height = height;
            Mass = mass;
            HairColor = hairColor;
            SkinColor = skinColor;
            EyeColor = eyeColor;
            BirthYear = birthYear;
            Gender = gender;
            Homeworld = homeworld;
        }
    }
}
