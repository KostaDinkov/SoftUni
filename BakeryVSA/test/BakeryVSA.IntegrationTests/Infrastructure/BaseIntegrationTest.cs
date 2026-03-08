using BakerySystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace BakeryVSA.IntegrationTests.Infrastructure;

public abstract class BaseIntegrationTest : IClassFixture<IntegrationTestWebAppFactory>, IAsyncLifetime
{
    protected readonly HttpClient Client;
    private readonly IServiceScope _scope;
    protected readonly BakeryDbContext DbContext;

    protected BaseIntegrationTest(IntegrationTestWebAppFactory factory)
    {
        _scope = factory.Services.CreateScope();
        Client = factory.CreateClient();
        DbContext = _scope.ServiceProvider.GetRequiredService<BakeryDbContext>();
    }

    public async ValueTask InitializeAsync()
    {
        await DbContext.Materials.ExecuteDeleteAsync();
        await DbContext.Vendors.ExecuteDeleteAsync();
    }

    public ValueTask DisposeAsync()
    {
        _scope.Dispose();
        return ValueTask.CompletedTask;
    }
}