using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WoofLodge.Api.Entities
{
    public class Image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public byte[] Data { get; set; }
        public string ContentType { get; set; }

        public Guid DogId { get; set; }
        public virtual Dog Dog { get; set; }
    }
}
