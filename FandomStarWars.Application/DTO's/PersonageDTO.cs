using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FandomStarWars.Application.DTO_s
{
    public class PersonageDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Height { get; set; }

        public string Mass { get; set; }

        public string HairColor { get; set; }
        
        public string SkinColor { get; set; }
       
        public string EyeColor { get; set; }
        
        public string BirthYear { get; set; }
        
        public string Gender { get; set; }
       
        public string Homeworld { get; set; }

        public string? Created { get; set; }

        public string? Edited { get; set; }

        public PersonageDTO()
        {

        }

        public PersonageDTO(int id, string name, string height, string mass, string hairColor, string skinColor, 
            string eyeColor, string birthYear, string gender, string homeworld, string created, string edited)
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
            Created = created;
            Edited = edited;
        }

        public PersonageDTO(string name, string height, string mass, string hairColor, string skinColor,
           string eyeColor, string birthYear, string gender, string homeworld, string created, string edited)
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
            Created = created;
            Edited = edited;
        }
    }
}
