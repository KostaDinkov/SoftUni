using BakerySystem.Domain;
using MediatR;
using BakerySystem.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace BakerySystem.Features.Materials.CreateMaterial;


public record CreateMaterialCommand(string Name, BaseUnit BaseUnit) : IRequest<Result<Guid>>;



public static class CreateMaterialEndpoint
{
    public static void MapCreateMaterialEndpoint(this IEndpointRouteBuilder builder)
    {
        builder.MapPost("/api/materials", async (CreateMaterialCommand command, IMediator mediator) =>
            {
                var result = await mediator.Send(command);
                return result.IsSuccess
                    ? Results.Created($"/api/materials/{result.Value}", result.Value)
                    : Results.BadRequest(result.Error);
            })
            .WithName("CreateMaterial")
            .WithOpenApi();

    }
}

public class CreateMaterialHandler (BakeryDbContext context) :IRequestHandler<CreateMaterialCommand, Result<Guid>> 
{
    
    public async Task<Result<Guid>> Handle(CreateMaterialCommand request, CancellationToken cancellationToken)
    {
        if (String.IsNullOrWhiteSpace(request.Name))
        {
            return Result<Guid>.Failure("Material name cannot be empty.");
        }
        var materialExists = await context.Materials.AnyAsync(m => m.Name == request.Name, cancellationToken);
        if (materialExists)
        {
            return Result<Guid>.Failure("A material with the same name already exists.");
        }

        var created = await context.Materials.AddAsync(new Material
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            BaseUnit = request.BaseUnit
        }, cancellationToken);

        await context.SharedSaveChangesAsync(cancellationToken);
        return Result<Guid>.Success(created.Entity.Id);
    }
}
