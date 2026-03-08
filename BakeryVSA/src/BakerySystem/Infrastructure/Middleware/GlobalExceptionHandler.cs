using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BakerySystem.Infrastructure.Middleware;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var isDevelopment = httpContext.RequestServices
            .GetRequiredService<IHostEnvironment>()
            .IsDevelopment();

        logger.LogError(exception, "An unhandled exception occurred: {Message}", exception.Message);

        var problemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = "Server Error",
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1",
            Detail = isDevelopment ? exception.Message : "An unexpected error occurred."
        };

        if (isDevelopment)
        {
            problemDetails.Detail = exception.Message;
            problemDetails.Extensions.Add("stackTrace", exception.StackTrace);
            problemDetails.Extensions.Add("exceptionType", exception.GetType().Name);
        }
        

        httpContext.Response.StatusCode = problemDetails.Status.Value;
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}

