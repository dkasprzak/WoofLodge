using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WoofLodge.Api.Entities
{
    public class Breed
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string BreedName { get; set; }
        public virtual ICollection<Dog> Dogs { get; set; }
    }
}
