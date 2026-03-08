using BakerySystem.Domain.Common;
using BakerySystem.Domain.Vendors;
using BakerySystem.Features.Vendors._Shared;
using BakerySystem.Infrastructure.Extensions;
using BakerySystem.Infrastructure.Persistence;
using Gridify;
using Gridify.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BakerySystem.Features.Vendors.GetVendors;

public record GetVendorsQuery(GridifyQuery GridifyQuery) : IRequest<Result<Paging<VendorResponse>>>;

public class GetVendorsEndpoint: IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapGet("/api/vendors", async ([AsParameters] GridifyQuery query, IMediator mediator) =>
            {
                var result = await mediator.Send(new GetVendorsQuery(query));

                return result.ToProblemDetails();
            })
            .WithName("GetVendors")
            .WithDescription("Supports Gridify filtering, sorting, and pagination.");
    }
}

public class GetVendorsHandler(BakeryDbContext context)
    : IRequestHandler<GetVendorsQuery, Result<Paging<VendorResponse>>>
{
    public async Task<Result<Paging<VendorResponse>>> Handle(GetVendorsQuery request, CancellationToken ct)
    {
        var mapper = new VendorMapper();

        var query = context.Vendors.AsNoTracking();
        
        var pagedData = await query.GridifyAsync(request.GridifyQuery, ct, mapper);

        var mappedItems = pagedData.Data.Select(v => v.ToResponse());

        return Result<Paging<VendorResponse>>.Success(new Paging<VendorResponse>(pagedData.Count,mappedItems));
    }
}

public class VendorMapper : GridifyMapper<Vendor>
{
    public VendorMapper()
    {
        this.GenerateMappings();
        AddMap("Email", v =>  v.ContactInfo!.Email);
        AddMap("PhoneNumber", v=> v.ContactInfo!.PhoneNumber );
        AddMap("Address", v => v.ContactInfo!.Address);
        AddMap("City", v => v.ContactInfo!.City);
        AddMap("Country", v => v.ContactInfo!.Country);
        AddMap("Uic", v =>  v.LegalInfo!.Uic);
        AddMap("VatNumber", v => v.LegalInfo!.VatNumber);
        AddMap("LegalAddress", v => v.LegalInfo!.LegalAddress);
        AddMap("Mol", v => v.LegalInfo!.Mol);
        AddMap("BankName", v => v.BankingInfo!.BankName);
        AddMap("Iban", v => v.BankingInfo!.Iban);
        AddMap("Swift", v => v.BankingInfo!.Swift);

    }
}

