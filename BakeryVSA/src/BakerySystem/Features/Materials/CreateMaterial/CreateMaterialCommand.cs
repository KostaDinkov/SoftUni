using BakerySystem.Domain.Common;
using BakerySystem.Domain.Shared;
using MediatR;

namespace BakerySystem.Features.Materials.CreateMaterial;

public record CreateMaterialCommand(string Name, BaseUnit BaseUnit) : IRequest<Result<Guid>>;