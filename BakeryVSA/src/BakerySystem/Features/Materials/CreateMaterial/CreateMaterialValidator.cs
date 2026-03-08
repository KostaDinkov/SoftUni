using FluentValidation;

namespace BakerySystem.Features.Materials.CreateMaterial;

public class CreateMaterialValidator: AbstractValidator<CreateMaterialCommand>
{
    public CreateMaterialValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Material name cannot be empty.")
            .MaximumLength(100).WithMessage("Material name cannot exceed 100 characters.")
            .Matches("^[a-zA-Z0-9 ]*$").WithMessage("Material name can only contain letters, numbers, and spaces.");
        RuleFor(x => x.BaseUnit)
            .IsInEnum().WithMessage("Please select a valid measurement unit.");
    }
}