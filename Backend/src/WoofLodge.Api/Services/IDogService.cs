using WoofLodge.Api.Commands;
using WoofLodge.Api.DTO;

namespace WoofLodge.Api.Services
{
    public interface IDogService
    {
        Task<IEnumerable<DogDTO>> GetAllAsync();
        Task<Guid?> CreateAsync(CreateDog command);
        Task<DogDTO> GetAsync(Guid Id);
        Task<bool> UpdateAsync(UpdateDog command);
    }
}
