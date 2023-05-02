using WoofLodge.Api.Entities;
using WoofLodge.Api.Enums;

namespace WoofLodge.Api.DTO
{
    public class DogDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string BreedName { get; set; }
        public string Description { get; set; }
        public DateTime RegistartionDate { get; set; }
        public string Sex { get; set; }
        public bool IsAvailable { get; set; }
        public Image Image { get; set; }
    }
}
