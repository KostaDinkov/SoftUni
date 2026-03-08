using BakerySystem.Domain.Common;
using MediatR;
using BakerySystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using BakerySystem.Domain.Materials;
using BakerySystem.Infrastructure.Extensions;

namespace BakerySystem.Features.Materials.CreateMaterial;

public class CreateMaterialEndpoint:IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapPost("/api/materials", async (CreateMaterialCommand command, IMediator mediator) =>
            {
                var result = await mediator.Send(command);
                return result.IsSuccess
                    ? Results.Created($"/api/materials/{result.Value}", result.Value)
                    : result.ToProblemDetails();
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

public class MaterialCreatedLogger(ILogger<MaterialCreatedLogger> logger)
    : INotificationHandler<MaterialCreatedEvent>
{
    public Task Handle(MaterialCreatedEvent notification, CancellationToken ct)
    {
        // This will show up in your console logs under the SAME TraceId as the Create command!
        logger.LogInformation("--- DOMAIN EVENT: Material '{Name}' was born with ID {Id} ---",
            notification.Name, notification.Id);

        return Task.CompletedTask;
    }
}