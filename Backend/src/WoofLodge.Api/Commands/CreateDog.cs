using WoofLodge.Api.Entities;
using WoofLodge.Api.Enums;

namespace WoofLodge.Api.Commands

{
    public sealed record CreateDog(Guid Id, string Name, Guid BreedId, string Description, 
                                    string Sex);
}
