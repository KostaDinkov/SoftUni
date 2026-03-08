using BakerySystem.Domain.Materials;
using BakerySystem.Features.Materials.GetMaterials;

namespace BakerySystem.Features.Materials._Shared;

public static class MaterialMappings
{
    public static MaterialResponse ToResponse(this Material material) =>
        new(
            material.Id,
            material.Name,
            material.BaseUnit
            );
}
