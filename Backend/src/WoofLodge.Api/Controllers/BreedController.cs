using Microsoft.AspNetCore.Mvc;
using WoofLodge.Api.Commands;
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

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<BreedDTO>> Get(Guid id)
        {
            var breed = await _breedService.GetAsync(id);
            
            if (breed is null)
            {
                return NotFound();
            }

            return Ok(breed);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateBreed command)
        {
            var breedId = await _breedService.CreateAsync(command with { Id = Guid.NewGuid()});
            
            if (breedId is null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(Get), new {breedId}, null);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (await _breedService.DeleteAsync(new DeleteBreed(id)))
            {
                return NoContent();
            }

            return NotFound();  
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update(Guid id, UpdateBreed command) 
        {
            if (await _breedService.UpdateAsync(command with { Id = id }))
            {
                return NoContent();
            }

            return NotFound();
        }

    }
}
