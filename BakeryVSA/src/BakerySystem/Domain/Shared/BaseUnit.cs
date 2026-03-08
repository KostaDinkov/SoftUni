namespace BakerySystem.Domain.Shared;

public enum BaseUnit
{
    Kg = 1,
    Liter = 2,
    Piece = 3,
}

public static class BaseUnitExtensions
{
    public static string ToDisplayString(this BaseUnit baseUnit)
    {
        return baseUnit switch
        {
            BaseUnit.Kg => "kg.",
            BaseUnit.Liter => "L.",
            BaseUnit.Piece => "Piece/s",
            _ => throw new ArgumentOutOfRangeException(nameof(baseUnit), $"Not expected base unit value: {baseUnit}")
        };
    }
}