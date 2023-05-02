using Microsoft.EntityFrameworkCore;
using WoofLodge.Api.Commands;
using WoofLodge.Api.Data;
using WoofLodge.Api.DTO;
using WoofLodge.Api.Entities;
using WoofLodge.Api.Enums;

namespace WoofLodge.Api.Services
{
    public class DogService : IDogService
    {
        private readonly WoofLodgeDbContext _dbContext;

        public DogService(WoofLodgeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<DogDTO>> GetAllAsync()
        {
           var dogs = await _dbContext
                .Dogs
                .Include(x => x.Image!)
                .Include(x => x.Breed)
                .ToListAsync();

            return dogs.Select(x => new DogDTO
            {
                Id = x.Id,
                Name = x.Name,
                BreedName = x.Breed.BreedName,
                Description = x.Description,
                RegistartionDate = x.RegistartionDate,
                Sex = x.Sex.ToString(),
                IsAvailable = x.IsAvailable,
                Image = x.Image,
            });
        }

        public async Task<DogDTO> GetAsync(Guid Id)
        {
            var dogs = await GetAllAsync();
            return dogs.SingleOrDefault(x => x.Id == Id);
        }

        public async Task<Guid?> CreateAsync(CreateDog command)
        {
            var dog = new Dog
            {
                Id = command.Id,
                Name = command.Name,
                BreedId = command.BreedId,
                Description = command.Description,
                RegistartionDate = DateTime.Now,
                Sex = (Sex)Enum.Parse(typeof(Sex), command.Sex),
                IsAvailable = true
            };

            await _dbContext.AddAsync(dog);
            await _dbContext.SaveChangesAsync();

            return dog.Id;
        }

        public async Task<bool> UpdateAsync(UpdateDog command)
        {
            var dog = await _dbContext.Dogs.SingleOrDefaultAsync(x => x.Id == command.Id);

            if (dog is null)
            {
                return false;
            }

            dog.Name = command.Name;
            dog.BreedId = command.BreedId;
            dog.Description = command.Description;
            dog.IsAvailable = command.IsAvailable;

            _dbContext.Update(dog);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
