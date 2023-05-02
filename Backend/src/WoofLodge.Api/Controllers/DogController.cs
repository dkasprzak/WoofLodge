using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;
using WoofLodge.Api.Commands;
using WoofLodge.Api.DTO;
using WoofLodge.Api.Services;

namespace WoofLodge.Api.Controllers;

[ApiController]
[Route("api/dogs")]
public class DogController : ControllerBase                                                                                                                                                                                                             
{
    private readonly IDogService _dogService;

    public DogController(IDogService dogService)
    {
        _dogService = dogService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DogDTO>>> Get() =>
        Ok(await _dogService.GetAllAsync());

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<DogDTO>> Get(Guid Id)
    {
        var dog = await _dogService.GetAsync(Id);

        if (dog is null)
        {
            return NotFound();
        }

        return Ok(dog);
    }

    [HttpPost]
    public async Task<ActionResult> Create(CreateDog command)
    {
        var dogId = await _dogService.CreateAsync(command with { Id = Guid.NewGuid()});

        if (dogId is null)
        {
            return BadRequest();
        }

        return CreatedAtAction(nameof(Get), new { dogId }, null);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, UpdateDog command)
    {
        if (await _dogService.UpdateAsync(command with { Id = id }))
        {
            return NoContent();
        }

        return NotFound();
    }

}