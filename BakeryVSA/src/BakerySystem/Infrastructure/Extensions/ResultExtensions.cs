using BakerySystem.Domain.Common;

namespace BakerySystem.Infrastructure.Extensions;

public static class ResultExtensions
{
    public static IResult ToProblemDetails<T>(this Result<T> result)
    {
        if (result.IsSuccess) return Results.Ok(result.Value);

        return result.Error.Type switch
        {
            ErrorType.Validation => Results.ValidationProblem(
                errors: result.Error.ValidationErrors ?? new Dictionary<string, string[]>(),
                detail: result.Error.Description,
                title: "Validation Error",
                type: "https://tools.ietf.org/html/rfc7231#section-6.5.1"),

            ErrorType.NotFound => Results.Problem(
                statusCode: StatusCodes.Status404NotFound,
                title: "Not Found",
                detail: result.Error.Description,
                type: "https://tools.ietf.org/html/rfc7231#section-6.5.4"),

            ErrorType.Conflict => Results.Problem(
                statusCode: StatusCodes.Status409Conflict,
                title: "Conflict",
                detail: result.Error.Description),

            _ => Results.Problem(
                statusCode: StatusCodes.Status400BadRequest,
                title: "Bad Request",
                detail: result.Error.Description)
        };
    }
}
