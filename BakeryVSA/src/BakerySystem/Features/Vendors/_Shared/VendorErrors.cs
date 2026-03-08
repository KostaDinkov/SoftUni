using BakerySystem.Domain.Common;

namespace BakerySystem.Features.Vendors._Shared;

public static class VendorErrors
{
    public static readonly Error DuplicateVendor = new(
        "Vendors.DuplicateVendorError",
        "The specified vendor already exists",
        ErrorType.Conflict
    );
}
