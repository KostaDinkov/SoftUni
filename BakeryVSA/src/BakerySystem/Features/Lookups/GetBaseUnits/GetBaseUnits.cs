using BakerySystem.Domain;

namespace BakerySystem.Features.Lookups.GetBaseUnits;

public record UnitLookupResponse(int Id, string Name, string Label);
public static class GetBaseUnitsEndPoint
{
    public static void MapGetBaseUnits(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/lookups/base-units", () =>
        {
            var baseUnits = Enum.GetValues<BaseUnit>()
                .Select(u => new UnitLookupResponse((int)u, u.ToString(), u.ToDisplayString()))
                .ToList();
            return Results.Ok(baseUnits);
        });
    }

}
