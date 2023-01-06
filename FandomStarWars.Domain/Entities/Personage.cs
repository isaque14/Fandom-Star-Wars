using FandomStarWars.Domain.Entities.Base;
using FandomStarWars.Domain.Validation;

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
        public ICollection<Film> Films { get; set; }

        public Personage(int id, string name, string height, string mass, string hairColor, string skinColor, string eyeColor, string birthYear, string gender,
            string homeworld)
        {
            DomainExceptionValidation.When(id >= 0, "Invalid Id");
            ValidationDomain(name, height, mass, hairColor, skinColor, eyeColor, birthYear, gender, homeworld);
            Created = DateTime.Now.ToString();
        }

        public Personage(string name, string height, string mass, string hairColor, string skinColor, string eyeColor, string birthYear, string gender,
            string homeworld)
        {
            ValidationDomain(name, height, mass, hairColor, skinColor, eyeColor, birthYear, gender, homeworld);
            Created = DateTime.Now.ToString();
        }

        public void Update(string name, string height, string mass, string hairColor, string skinColor, string eyeColor, string birthYear, string gender,
            string homeworld)
        {
            ValidationDomain(name, height, mass, hairColor, skinColor, eyeColor, birthYear, gender, homeworld);
            Edited = DateTime.Now.ToString();
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
