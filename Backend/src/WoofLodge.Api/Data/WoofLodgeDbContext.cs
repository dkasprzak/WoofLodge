using Microsoft.EntityFrameworkCore;
using WoofLodge.Api.Entities;
using WoofLodge.Api.Enums;

namespace WoofLodge.Api.Data
{
    public class WoofLodgeDbContext : DbContext
    {
        public WoofLodgeDbContext(DbContextOptions<WoofLodgeDbContext> options) : base(options)
        {            
        }

        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Dog>()
                .HasKey(d => d.Id);
            builder.Entity<Dog>()
                .Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Entity<Dog>()
                .Property(d => d.Description)
                .IsRequired()
                .HasMaxLength(3000);
            builder.Entity<Dog>()
                .Property(d => d.IsAvailable)
                .IsRequired();
            builder.Entity<Dog>()
                .Property(d => d.RegistartionDate)
                .IsRequired();
            builder.Entity<Dog>()
                .Property(d => d.Sex)
                .IsRequired()
                .HasConversion(d => d.ToString(),
                d => (Sex)Enum.Parse(typeof(Sex), d));

            builder.Entity<Breed>()
                .HasKey(b => b.Id);
            builder.Entity<Breed>()
                .Property(b => b.BreedName)
                .IsRequired()
                .HasMaxLength(100);
            builder.Entity<Breed>();

            builder.Entity<Image>()
                .HasKey(i => i.Id);
            builder.Entity<Image>()
                .Property(i => i.Data)
                .IsRequired();
            builder.Entity<Image>()
                .Property(i => i.ContentType)
                .IsRequired();
    

            //Relationships
            builder.Entity<Dog>()
                .HasOne(x => x.Breed)
                .WithMany(x => x.Dogs)
                .HasForeignKey(x => x.BreedId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Dog>()
                .HasOne(x => x.Image)
                .WithOne(i => i.Dog)
                .HasForeignKey<Image>(i => i.DogId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
