using BakerySystem.Domain;
using Dapper;
using MediatR;
using Npgsql;

namespace BakerySystem.Features.Vendors.GetVendors;

public record VendorResponse(Guid Id, string Name);

public record GetVendorsQuery : IRequest<Result<IEnumerable<VendorResponse>>>;

public static class GetVendorsEndpoint
{
    public static void MapGetVendors(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/vendors", async (IMediator mediator) =>
            {
                var vendors = await mediator.Send(new GetVendorsQuery());
                return Results.Ok(vendors);
            })
            .WithName("GetVendors")
            .WithOpenApi(); // This makes it show up in Swagger!
    }
}

public class GetVendorsHandler: IRequestHandler<GetVendorsQuery, Result<IEnumerable<VendorResponse>>>
{
   private readonly IConfiguration _configuration;

   public GetVendorsHandler(IConfiguration configuration)
   {
       _configuration = configuration;
   }

   public async Task<Result<IEnumerable<VendorResponse>>> Handle(GetVendorsQuery request, CancellationToken ct)
   {
       var connectionString = _configuration.GetConnectionString("DefaultConnection");
        
        await using var connection = new NpgsqlConnection(connectionString);
        const string sql = @"
            SELECT Id, Name
            FROM public.Vendors";
        var vendors = await connection.QueryAsync<VendorResponse>(sql);
        return Result<IEnumerable<VendorResponse>>.Success(vendors);
    }
}

