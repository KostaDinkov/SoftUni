using MediatR;
using BakerySystem.Features.Vendors._Shared;
using BakerySystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

using BakerySystem.Domain.Vendors;
using BakerySystem.Domain.Common;
using BakerySystem.Infrastructure.Extensions;

namespace BakerySystem.Features.Vendors.CreateVendor;


public class CreateVendorEndpoint: IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapPost("/api/vendors", async (CreateVendorCommand command, IMediator mediator) =>
            {

                var result = await mediator.Send(command);

                return result.IsSuccess
                    ? Results.Created($"/api/vendors/{result.Value}", result.Value)
                    : result.ToProblemDetails();
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


