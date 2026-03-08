namespace BakerySystem.Domain.Vendors;

public record LegalInfo(
    string? Uic = null,
    string? VatNumber = null,
    string? LegalAddress = null,
    string? Mol = null
    );