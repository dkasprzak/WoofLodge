using WoofLodge.Api.Commands;
using WoofLodge.Api.DTO;

namespace WoofLodge.Api.Services
{
    public interface IBreedService
    {
        Task<IEnumerable<BreedDTO>> GetAllAsync();
        Task<BreedDTO> GetAsync(Guid id);
        Task<Guid?> CreateAsync(CreateBreed command);
        Task<bool> DeleteAsync(DeleteBreed command);
        Task<bool> UpdateAsync(UpdateBreed command);
    }
}
