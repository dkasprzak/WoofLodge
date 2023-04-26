using WoofLodge.Api.Enums;

namespace WoofLodge.Api.Entities
{
    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public DateTime RegistartionDate { get; set; }
        public Sex Sex { get; set; }
        public bool IsAvailable { get; set; }
        public virtual Image Image { get; set; }

        public int BreedId { get; set; }
        public virtual Breed Breed { get; set; }
    }
}
