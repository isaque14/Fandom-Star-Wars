namespace FandomStarWars.Application.Personages.Commands.Base
{
    public abstract class PersonageCommand 
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

    }
}
