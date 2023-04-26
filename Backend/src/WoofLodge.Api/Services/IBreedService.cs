using WoofLodge.Api.DTO;

namespace WoofLodge.Api.Services
{
    public interface IBreedService
    {
        Task<IEnumerable<BreedDTO>> GetAllAsync();
        Task<BreedDTO> GetAsync(int id);    
    }
}
