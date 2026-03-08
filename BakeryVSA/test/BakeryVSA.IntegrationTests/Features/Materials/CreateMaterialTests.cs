using System.Net;
using System.Net.Http.Json;
using BakerySystem.Domain.Shared;
using BakerySystem.Features.Materials.CreateMaterial;
using BakeryVSA.IntegrationTests.Infrastructure;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace BakeryVSA.IntegrationTests.Features.Materials;

public class CreateMaterialTests(IntegrationTestWebAppFactory factory)
    : BaseIntegrationTest(factory)
{
    [Fact]
    public async Task CreateMaterial_WithValidData_Returns201()
    {
        var command = new CreateMaterialCommand("Flour", BaseUnit.Kg);

        var response = await Client.PostAsJsonAsync("/api/materials", command);

        response.StatusCode.Should().Be(HttpStatusCode.Created);
        var id = await response.Content.ReadFromJsonAsync<Guid>();
        id.Should().NotBeEmpty();
    }

    [Fact]
    public async Task CreateMaterial_WithValidData_PersistsMaterial()
    {
        var command = new CreateMaterialCommand("Sugar", BaseUnit.Kg);

        await Client.PostAsJsonAsync("/api/materials", command);

        var exists = await DbContext.Materials.AnyAsync(m => m.Name == "Sugar");
        exists.Should().BeTrue();
    }

    [Fact]
    public async Task CreateMaterial_WithDuplicateName_Returns409()
    {
        var command = new CreateMaterialCommand("Butter", BaseUnit.Kg);
        await Client.PostAsJsonAsync("/api/materials", command);

        var response = await Client.PostAsJsonAsync("/api/materials", command);

        response.StatusCode.Should().Be(HttpStatusCode.Conflict);
    }

    [Fact]
    public async Task CreateMaterial_WithEmptyName_Returns400()
    {
        var command = new CreateMaterialCommand("", BaseUnit.Kg);

        var response = await Client.PostAsJsonAsync("/api/materials", command);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}