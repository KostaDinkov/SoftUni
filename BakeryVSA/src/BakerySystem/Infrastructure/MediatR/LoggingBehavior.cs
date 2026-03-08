using System.Diagnostics;
using MediatR;

namespace BakerySystem.Infrastructure.MediatR;

public class LoggingBehavior<TRequest, TResponse>
    (ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    :IPipelineBehavior<TRequest,TResponse>
    where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(
        TRequest request, 
        RequestHandlerDelegate<TResponse> next, 
        CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;

        using (logger.BeginScope(
                   new Dictionary<string, object> { ["RequestName"] = requestName }))
        {
            logger.LogInformation("Processing request {RequestName}", requestName);
            var sw = Stopwatch.StartNew();
            try
            {
                var response = await next();
                sw.Stop();
                logger.LogInformation(
                    "Completed request {RequestName} in {ElapsedMilliseconds} ms",
                    requestName, sw.ElapsedMilliseconds);
                return response;
            }
            catch (Exception ex)
            {
                sw.Stop();
                logger.LogError(ex, "Error processing request {RequestName} after {ElapsedMilliseconds} ms", requestName, sw.ElapsedMilliseconds);
                throw;
            }
        }
    }
}
