namespace BakerySystem.Domain.Common;

public record Error(
    string Code, 
    string Description, 
    ErrorType Type, 
    IDictionary<string, string[]>? ValidationErrors = null)
{
    public static readonly Error None = new(string.Empty, string.Empty, ErrorType.Failure);
    public static readonly Error NullValue = new("Error.NullValue", "Null value was provided", ErrorType.Failure);
    public static Error ValidationError(IDictionary<string, string[]> errors) =>
        new("General.Validation", "One or more validation errors occurred.", ErrorType.Validation, errors);
}

public enum ErrorType
{
    Failure = 0,
    Validation = 1,
    NotFound = 2,
    Conflict = 3,
    Unauthorized = 4
}