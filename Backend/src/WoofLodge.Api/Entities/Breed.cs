namespace WoofLodge.Api.Entities
{
    public class Breed
    {
        public int Id { get; set; }
        public string BreedName { get; set; }
        public virtual ICollection<Dog> Dogs { get; set; }
    }
}
