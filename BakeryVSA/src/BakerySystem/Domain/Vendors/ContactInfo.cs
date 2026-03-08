namespace BakerySystem.Domain.Vendors;

public record ContactInfo(
    string? Email = null,
    string? PhoneNumber = null ,
    string? Address = null,
    string? City = null,
    string? Country = null);