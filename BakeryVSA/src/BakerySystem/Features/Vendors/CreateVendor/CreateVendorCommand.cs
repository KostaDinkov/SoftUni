using BakerySystem.Domain.Common;
using BakerySystem.Domain.Vendors;
using FluentValidation;
using MediatR;

namespace BakerySystem.Features.Vendors.CreateVendor;

public record CreateVendorCommand(
    string Name,
    ContactInfoCommand? ContactInfo = null,
    LegalInfoCommand? LegalInfo = null,
    BankingInfoCommand? BankingInfo = null
) : IRequest<Result<Guid>>;

public record BankingInfoCommand(string? BankName = null, string? Iban = null, string? Swift = null)
{
    public BankingInfo ToBankingInfo()
    {
        return new BankingInfo(BankName, Iban, Swift);
    }
}
public record ContactInfoCommand(
    string? Email = null,
    string? PhoneNumber = null,
    string? Address = null,
    string? City = null,
    string? Country = null)
{
    public ContactInfo ToContactInfo()
    {
        return new ContactInfo(Email, PhoneNumber, Address, City, Country);
    }
};

public record LegalInfoCommand(
    string? Uic = null,
    string? VatNumber = null,
    string? LegalAddress = null,
    string? Mol = null)
{
    public LegalInfo ToLegalInfo()
    {
        return new LegalInfo(Uic, VatNumber, LegalAddress, Mol);
    }
};