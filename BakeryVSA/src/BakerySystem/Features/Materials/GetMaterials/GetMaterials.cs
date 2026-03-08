using BakerySystem.Domain.Common;
using BakerySystem.Domain.Materials;
using BakerySystem.Domain.Shared;
using BakerySystem.Features.Materials._Shared;
using BakerySystem.Infrastructure.Extensions;
using BakerySystem.Infrastructure.Persistence;
using Gridify;
using Gridify.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace BakerySystem.Features.Materials.GetMaterials;

public record MaterialResponse(Guid Id, string Name,  BaseUnit BaseUnit);

public record GetMaterialsQuery (GridifyQuery GridifyQuery): IRequest<Result<Paging<MaterialResponse>>>;

public class GetMaterialsHandler(BakeryDbContext context):IRequestHandler<GetMaterialsQuery, Result<Paging<MaterialResponse>>>
{

    public async Task<Result<Paging<MaterialResponse>>> Handle(GetMaterialsQuery request, CancellationToken cancellationToken)
    {
        
        var mapper = new GridifyMapper<Material>();

        var materials = context.Materials.AsNoTracking();

        var pagedData = await materials.GridifyAsync(request.GridifyQuery, cancellationToken, mapper);

        var mappedItems = pagedData.Data.Select(m => m.ToResponse());
        return Result<Paging<MaterialResponse>>.Success(new Paging<MaterialResponse>(pagedData.Count, mappedItems ));
    }
}

public class GetMaterialsEndpoint:IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapGet("/api/materials", async ([AsParameters] GridifyQuery query,IMediator mediator) =>
            {
                var result = await mediator.Send(new GetMaterialsQuery(query));

                return result.ToProblemDetails();
            })
            .WithName("GetMaterials");

    }
}
