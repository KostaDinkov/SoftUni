namespace BakerySystem.Domain.Vendors;

public record BankingInfo(
    string? BankName = null , 
    string? Iban = null, 
    string? Swift = null);