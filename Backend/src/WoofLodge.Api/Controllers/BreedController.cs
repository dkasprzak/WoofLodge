using Microsoft.AspNetCore.Mvc;
using WoofLodge.Api.DTO;
using WoofLodge.Api.Services;

namespace WoofLodge.Api.Controllers
{
    [ApiController]
    [Route("api/breeds")]
    public class BreedController : ControllerBase
    {
        private readonly IBreedService _breedService;

        public BreedController(IBreedService breedService)
        {
            _breedService = breedService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BreedDTO>>> Get() =>
             Ok(await _breedService.GetAllAsync());

        [HttpGet("{id:int}")]
        public async Task<ActionResult<BreedDTO>> Get(int id)
        {
            var breed = await _breedService.GetAsync(id);
            
            if (breed is null)
            {
                return NotFound();
            }

            return Ok(breed);
        }
        
    }
}
