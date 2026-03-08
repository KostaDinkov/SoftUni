using BakerySystem.Domain.Common;
using BakerySystem.Domain.Shared;

namespace BakerySystem.Domain.Materials;

public class Material : Entity
{
    private Material() { }
    public string Name { get; private set; } = null!;

    public BaseUnit BaseUnit { get; private set; }

    public static Result<Material> Create(string name, BaseUnit baseUnit)
    {
        var material = new Material
        {
            Name = name.Trim(),
            BaseUnit = baseUnit
        };

        return material;
    }
}
