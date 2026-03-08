using FluentValidation;

namespace BakerySystem.Features.Vendors.CreateVendor;

public class CreateVendorValidator : AbstractValidator<CreateVendorCommand>
{
    public CreateVendorValidator()
    {
        RuleFor(v => v.Name)
            .NotEmpty().WithMessage("Vendor name is required.")
            .MinimumLength(2).WithMessage("Vendor name must be at least 2 characters long.")
            .MaximumLength(100).WithMessage("Vendor name must be less than 100 characters long.");
        RuleFor(v => v.ContactInfo!)
            .SetValidator(new ContactInfoValidator())
            .When(v => v.ContactInfo != null);
        RuleFor(v => v.LegalInfo!)
            .SetValidator(new LegalInfoValidator())
            .When(v => v.LegalInfo != null);
        RuleFor(v => v.BankingInfo!)
            .SetValidator(new BankingInfoValidator())
            .When(v => v.BankingInfo != null);
    }
}

public class BankingInfoValidator : AbstractValidator<BankingInfoCommand>
{
    public BankingInfoValidator()
    {
        RuleFor(l => l.BankName)
            .MaximumLength(100).WithMessage("Bank name must be less than 100 characters long.")
            .MinimumLength(2).WithMessage("Bank name must be at least 2 characters long.")
            .When(l => !string.IsNullOrEmpty(l.BankName));
        RuleFor(b => b.Iban)
            .Matches(@"^[A-Z]{2}\d{2}[A-Z0-9]{1,30}$").WithMessage("Invalid IBAN format.")
            .When(b => !string.IsNullOrEmpty(b.Iban));
        RuleFor(b => b.Swift)
            .Matches(@"^[A-Z]{6}[A-Z0-9]{2}([A-Z0-9]{3})?$").WithMessage("Invalid SWIFT format.")
            .When(b => !string.IsNullOrEmpty(b.Swift));
    }
}

public class ContactInfoValidator : AbstractValidator<ContactInfoCommand>
{
    public ContactInfoValidator()
    {
        RuleFor(c => c.Email)
            .EmailAddress().WithMessage("Invalid email format.")
            .When(c => !string.IsNullOrEmpty(c.Email));
        RuleFor(c => c.PhoneNumber)
            .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Invalid phone number format.")
            .When(c => !string.IsNullOrEmpty(c.PhoneNumber));
    }
}

public class LegalInfoValidator : AbstractValidator<LegalInfoCommand>
{
    public LegalInfoValidator()
    {
        RuleFor(l => l.Uic)
            .Matches(@"^[A-Z0-9]{8,12}$").WithMessage("UIC must be 8-12 alphanumeric characters.")
            .When(l => !string.IsNullOrEmpty(l.Uic));
        RuleFor(l => l.VatNumber)
            .Matches(@"^[A-Z0-9]{8,15}$").WithMessage("VAT number must be 8-15 alphanumeric characters.")
            .When(l => !string.IsNullOrEmpty(l.VatNumber));
    }
}