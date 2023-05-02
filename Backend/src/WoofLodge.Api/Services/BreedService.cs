using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using WoofLodge.Api.Commands;
using WoofLodge.Api.Data;
using WoofLodge.Api.DTO;
using WoofLodge.Api.Entities;

namespace WoofLodge.Api.Services
{
    public class BreedService : IBreedService
    {
        private readonly WoofLodgeDbContext _woofLodgeDbContext;

        public BreedService(WoofLodgeDbContext woofLodgeDbContext)
        {
            _woofLodgeDbContext = woofLodgeDbContext;
        }

        public async Task<IEnumerable<BreedDTO>> GetAllAsync()
        {
            var breeds = await _woofLodgeDbContext
                .Breeds
                .ToListAsync();

            return breeds
                .Select(x => new BreedDTO 
                { 
                    Id = x.Id, 
                    BreedName = x.BreedName 
                });
        }

        public async Task<BreedDTO> GetAsync(Guid id)
        {
            var breeds = await GetAllAsync();
            return breeds.SingleOrDefault(x => x.Id == id);
        }


        public async Task<Guid?> CreateAsync(CreateBreed command)
        {
            var breed = new Breed
            {
                Id = command.Id,
                BreedName = command.BreedName
            };

            await _woofLodgeDbContext.AddAsync(breed);
            await _woofLodgeDbContext.SaveChangesAsync();
            return breed.Id;    
        }

        public async Task<bool> DeleteAsync(DeleteBreed command)
        {
            var breed = await _woofLodgeDbContext.Breeds.SingleOrDefaultAsync(x => x.Id == command.Id);
           
            if (breed is null)
            {
                return false;
            }

            _woofLodgeDbContext.Remove(breed);
            await _woofLodgeDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(UpdateBreed command)
        {
            var breed = await _woofLodgeDbContext.Breeds.SingleOrDefaultAsync(x => x.Id == command.Id);

            if (breed is null) 
            {
                return false;
            }

            breed.BreedName = command.BreedName;

            _woofLodgeDbContext.Update(breed);
            await _woofLodgeDbContext.SaveChangesAsync();
            return true;
        }
    }
}
