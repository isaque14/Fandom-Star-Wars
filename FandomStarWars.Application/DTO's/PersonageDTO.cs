using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FandomStarWars.Application.DTO_s
{
    public class PersonageDTO
    {
        [Required(ErrorMessage = "Name is Required")]
        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Heigth")]
        public string Height { get; set; }

        [DisplayName("Mass")]
        public string Mass { get; set; }

        [DisplayName("HairColor")]
        public string HairColor { get; set; }
        
        [DisplayName("SkinColor")]
        public string SkinColor { get; set; }
       
        [DisplayName("EyeColor")]
        public string EyeColor { get; set; }
        
        [DisplayName("BirthYear")]
        public string BirthYear { get; set; }
        
        [DisplayName("Gender")]
        public string Gender { get; set; }
       
        [DisplayName("Homeworld")]
        public string Homeworld { get; set; }
        
        [DisplayName("Created")]
        public string Created { get; set; }

        [DisplayName("Edited")]
        public string Edited { get; set; }

        

        public PersonageDTO(string name, string height, string mass, string hairColor, string skinColor, string eyeColor, string birthYear,
         string gender, string homeworld, string created, string edited)
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
