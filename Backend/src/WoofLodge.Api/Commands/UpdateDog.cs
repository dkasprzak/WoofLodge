using WoofLodge.Api.Entities;
using WoofLodge.Api.Enums;

namespace WoofLodge.Api.Commands

{
    public sealed record UpdateDog(Guid Id, string Name, Guid BreedId, string Description, bool IsAvailable);
}
