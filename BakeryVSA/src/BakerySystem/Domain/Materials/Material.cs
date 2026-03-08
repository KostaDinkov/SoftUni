using BakerySystem.Domain.Common;
using BakerySystem.Domain.Shared;

namespace BakerySystem.Domain.Materials;

public class Material : Entity
{
    public static class Errors
    {
        public static Error InvalidName =>
            new("Material.InvalidName", "Name must be between 1 and 100 characters.", ErrorType.Validation);
        public static Error InvalidBaseUnit =>
            new("Material.InvalidBaseUnit", "The provided base unit is not valid.", ErrorType.Validation);
    }
    private Material() { }
    public string Name { get; private set; } = null!;

    public BaseUnit BaseUnit { get; private set; }

    public static Result<Material> Create(string name, BaseUnit baseUnit)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length > 100) return Errors.InvalidName;
        if (!Enum.IsDefined(baseUnit)) return Errors.InvalidBaseUnit;
        var material = new Material
        {
            Name = name.Trim(),
            BaseUnit = baseUnit
        };

        material.RaiseDomainEvent(new MaterialCreatedEvent(material.Id, material.Name));

        return material;
    }
}

public record MaterialCreatedEvent(Guid Id, string Name) : IDomainEvent;
