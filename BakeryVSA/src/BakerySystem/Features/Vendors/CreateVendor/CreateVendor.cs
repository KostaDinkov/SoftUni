using MediatR;
using BakerySystem.Domain;
using BakerySystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BakerySystem.Features.Vendors.CreateVendor;

public record CreateVendorCommand(string Name) : IRequest<Result<Guid>>;
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
            .WithName("CreateVendor")
            .WithOpenApi(); // This makes it show up in Swagger!
    }
}


public class CreateVendorHandler : IRequestHandler<CreateVendorCommand, Result<Guid>>
{
    private readonly BakeryDbContext _context;

    public CreateVendorHandler(BakeryDbContext context)
    {
        _context = context;
    }
    public async Task<Result<Guid>> Handle(CreateVendorCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            return Result<Guid>.Failure("Vendor name cannot be empty");
        }

        if (await _context.Vendors.AnyAsync(v => v.Name == request.Name))
        {
            return Result<Guid>.Failure($"A vendor named '{request.Name}' already exists");
        }
        var vendor = new Vendor { Id = Guid.NewGuid(), Name = request.Name };

        _context.Vendors.Add(vendor);
        await _context.SharedSaveChangesAsync(cancellationToken);

        return Result<Guid>.Success(vendor.Id);
    }
}


