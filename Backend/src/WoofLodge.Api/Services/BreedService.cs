using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using WoofLodge.Api.Data;
using WoofLodge.Api.DTO;

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

        public async Task<BreedDTO> GetAsync(int id)
        {
            var breeds = await GetAllAsync();
            return breeds.SingleOrDefault(x => x.Id == id);
        }
    }
}
