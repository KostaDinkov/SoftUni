using BakerySystem.Domain.Shared;
using BakerySystem.Infrastructure.Extensions;

namespace BakerySystem.Features.Lookups.GetBaseUnits;

public record UnitLookupResponse(int Id, string Name, string Label);
public class GetBaseUnitsEndPoint:IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapGet("/api/lookups/base-units", () =>
        {
            var baseUnits = Enum.GetValues<BaseUnit>()
                .Select(u => new UnitLookupResponse((int)u, u.ToString(), u.ToDisplayString()))
                .ToList();
            return Results.Ok(baseUnits);
        });
    }

}
