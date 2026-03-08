namespace BakerySystem.Features.Vendors._Shared;

public record VendorResponse(
    Guid Id,
    string Name,
    string? Email,
    string? PhoneNumber,
    string? Address,
    string? City,
    string? Country,
    string? Uic,
    string? VatNumber,
    string? LegalAddress,
    string? Mol,
    string? BankName,
    string? Iban,
    string? Swift
);