using BakerySystem.Domain.Common;
using BakerySystem.Domain.Vendors;

namespace BakerySystem.Domain.Vendors;

public class Vendor:Entity
{

    
    private Vendor() { }
    
    public string Name { get; private set; } = null!;
    public ContactInfo? ContactInfo { get; private set; }
    public LegalInfo? LegalInfo { get; private set; }
    public BankingInfo? BankingInfo { get; private set; }

    public static Result<Vendor> Create(string name, ContactInfo? contactInfo, LegalInfo? legalInfo, BankingInfo? bankingInfo)
    {
        var vendor = new Vendor
        {
            
            Name = name.Trim(),
            ContactInfo = contactInfo,
            LegalInfo = legalInfo,
            BankingInfo = bankingInfo
        };
        return vendor;
    }
}