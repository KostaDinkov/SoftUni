using BakerySystem.Domain.Common;
using MediatR;
using BakerySystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using BakerySystem.Domain.Materials;

namespace BakerySystem.Features.Materials.CreateMaterial;

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
            .WithName("CreateMaterial");


    }
}

public class CreateMaterialHandler (BakeryDbContext context) :IRequestHandler<CreateMaterialCommand, Result<Guid>> 
{
    
    public async Task<Result<Guid>> Handle(CreateMaterialCommand request, CancellationToken cancellationToken)
    {


        var materialExists = await context.Materials.AnyAsync(m => m.Name == request.Name, cancellationToken);
        if (materialExists)
        {
            return new Error(
                "Materials.DuplicateMaterial",
                "A material with the same name already exists.",
                ErrorType.Conflict
                );
        }


        var materialResult = Material.Create(request.Name, request.BaseUnit);

        if (!materialResult.IsSuccess)
        {
            return Result<Guid>.Failure(materialResult.Error);
        }

        var created = await context.Materials.AddAsync(materialResult.Value, cancellationToken);

        await context.SharedSaveChangesAsync(cancellationToken);
        return Result<Guid>.Success(created.Entity.Id);
    }
}