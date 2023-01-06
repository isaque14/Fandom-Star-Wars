using FandomStarWars.Domain.Entities.Base;

namespace FandomStarWars.Domain.Entities
{
    public class Planet : Entity
    {
        public string Name { get; set; }
        public string RotationPeriod { get; set; }
        public string OrbitalPeriod { get; set; }
        public string Diameter { get; set; }
        public string Climate { get; set; }
        public string Gravity { get; set; }
        public string Terrain { get; set; }
        public string SurfaceWater { get; set; }
        public string Population { get; set; }
        public List<string> Residents { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
    }
}
