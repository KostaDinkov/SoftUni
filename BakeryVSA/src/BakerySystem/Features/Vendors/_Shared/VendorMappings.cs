using BakerySystem.Domain.Vendors;

namespace BakerySystem.Features.Vendors._Shared;

public static class VendorMappings
{
    public static VendorResponse ToResponse(this Vendor v) =>
        new VendorResponse(
            v.Id,
            v.Name,
            v.ContactInfo?.Email,
            v.ContactInfo?.PhoneNumber,
            v.ContactInfo?.Address,
            v.ContactInfo?.City,
            v.ContactInfo?.Country,
            v.LegalInfo?.Uic,
            v.LegalInfo?.VatNumber,
            v.LegalInfo?.LegalAddress,
            v.LegalInfo?.Mol,
            v.BankingInfo?.BankName,
            v.BankingInfo?.Iban,
            v.BankingInfo?.Swift
        );
}
