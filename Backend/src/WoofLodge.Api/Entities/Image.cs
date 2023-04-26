namespace WoofLodge.Api.Entities
{
    public class Image
    {
        public int  Id { get; set; }
        public byte[] Data { get; set; }
        public string ContentType { get; set; }

        public int DogId { get; set; }
        public virtual Dog Dog { get; set; }
    }
}
