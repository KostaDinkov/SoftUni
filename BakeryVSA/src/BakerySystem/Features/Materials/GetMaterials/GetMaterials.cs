using BakerySystem.Domain;
using Dapper;
using MediatR;
using Npgsql;

namespace BakerySystem.Features.Materials.GetMaterials;

public record MaterialResponse(string Name, Guid Id, BaseUnit BaseUnit);

public record GetMaterialsQuery : IRequest<Result<IEnumerable<MaterialResponse>>>;

public class GetMaterialsHandler(IConfiguration configuration):IRequestHandler<GetMaterialsQuery, Result<IEnumerable<MaterialResponse>>>
{

    public async Task<Result<IEnumerable<MaterialResponse>>> Handle(GetMaterialsQuery request, CancellationToken cancellationToken)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        await using var connection = new NpgsqlConnection(connectionString);
        var sql = @"Select name, id, base_unit from materials";

        var result = await connection.QueryAsync<MaterialResponse>(sql);
        return Result<IEnumerable<MaterialResponse>>.Success(result);
    }
}

public static class GetMaterialsEndpoint
{
    public static void MapGetMaterials(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/materials", async (IMediator mediator) =>
            {
                var result = await mediator.Send(new GetMaterialsQuery());

                return result.IsSuccess
                    ? Results.Ok(result.Value)
                    : Results.BadRequest(result.Error);
            })
            .WithName("GetMaterials")
            .WithOpenApi();
    }
}
