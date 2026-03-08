using MediatR;
using BakerySystem.Features.Vendors._Shared;
using BakerySystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

using BakerySystem.Domain.Vendors;
using BakerySystem.Domain.Common;

namespace BakerySystem.Features.Vendors.CreateVendor;


public static class CreateVendorEndpoint
{
    public static void MapCreateVendor(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/vendors", async (CreateVendorCommand command, IMediator mediator) =>
            {

                var result = await mediator.Send(command);

                return result.IsSuccess
                    ? Results.Created($"/api/vendors/{result.Value}", result.Value)
                    : Results.BadRequest(result.Error);
            })
            .WithName("CreateVendor");

    }
}


public class CreateVendorHandler(BakeryDbContext context) : IRequestHandler<CreateVendorCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateVendorCommand request, CancellationToken cancellationToken)
    {
        

        if (await context.Vendors.AnyAsync(v => v.Name == request.Name, cancellationToken))
        {
            return Result<Guid>.Failure(VendorErrors.DuplicateVendor);
        }
        var vendorResult = Vendor.Create(
            request.Name,
            request.ContactInfo?.ToContactInfo(),
            request.LegalInfo?.ToLegalInfo(),
            request.BankingInfo?.ToBankingInfo()
        );
        
        if (vendorResult.IsFailure)
        {
            return Result<Guid>.Failure(vendorResult.Error);
        }

        await context.Vendors.AddAsync(vendorResult.Value, cancellationToken);
        await context.SharedSaveChangesAsync(cancellationToken);

        return Result<Guid>.Success(vendorResult.Value.Id);
    }
}


