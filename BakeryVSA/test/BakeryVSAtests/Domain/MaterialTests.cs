using BakerySystem.Domain.Materials;
using BakerySystem.Domain.Shared;
using FluentAssertions;

namespace BakeryVSAtests.Domain;



public class MaterialTests
{
    [Fact]
    public void Create_WithValidData_ReturnsSuccess()
    {
        var result = Material.Create("Flour", BaseUnit.Kg);

        result.IsSuccess.Should().BeTrue();
        result.Value.Name.Should().Be("Flour");
        result.Value.BaseUnit.Should().Be(BaseUnit.Kg);
        result.Value.Id.Should().NotBeEmpty();
    }

    [Fact]
    public void Create_TrimsName()
    {
        var result = Material.Create("  Flour  ", BaseUnit.Kg);

        result.Value.Name.Should().Be("Flour");
    }
    [Theory]
    [InlineData("")]
    [InlineData("  ")]
    public void Create_WithEmptyName_ReturnsInvalidNameError(string name)
    {
        var result = Material.Create(name, BaseUnit.Kg);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(Material.Errors.InvalidName);
    }
    [Fact]
    public void Create_WithNameOver100Chars_ReturnsInvalidNameError()
    {
        var result = Material.Create(new string('A', 101), BaseUnit.Kg);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(Material.Errors.InvalidName);
    }

    [Fact]
    public void Create_WithInvalidBaseUnit_ReturnsInvalidBaseUnitError()
    {
        var result = Material.Create("Flour", (BaseUnit)99);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(Material.Errors.InvalidBaseUnit);
    }

    [Fact]
    public void Create_WithValidData_RaisesMaterialCreatedEvent()
    {
        var result = Material.Create("Flour", BaseUnit.Kg);

        result.Value.DomainEvents.Should().ContainSingle()
            .Which.Should().BeOfType<MaterialCreatedEvent>();

        var evt = (MaterialCreatedEvent)result.Value.DomainEvents[0];
        evt.Name.Should().Be("Flour");
        evt.Id.Should().Be(result.Value.Id);
    }

    [Fact]
    public void Create_WhenFails_DoesNotRaiseDomainEvent()
    {
        var result = Material.Create("", BaseUnit.Kg);

        result.IsFailure.Should().BeTrue();
        // No entity created, no events raised
    }
}
