using BakerySystem.Domain;
using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BakerySystem.Infrastructure.MediatR;

public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) 
    : IPipelineBehavior<TRequest,TResponse> where TRequest : notnull
{
    public async Task<TResponse> Handle(
        TRequest request, 
        RequestHandlerDelegate<TResponse> next, 
        CancellationToken cancellationToken)
    {
        if (!validators.Any()) return await next();

        var context = new ValidationContext<TRequest>(request);

        var validationResults = await Task.WhenAll(
            validators.Select(v=> v.ValidateAsync(context, cancellationToken)));

        var failures = validationResults
            .SelectMany(r => r.Errors)
            .Where(f=> f != null)
            .ToList();

        if( failures.Count != 0)
        {
            // We assume the TResponse is of type Result<T>
            // This is the one "opinionated" part of our pipeline
            var firstError = failures[0].ErrorMessage;

            if (typeof(TResponse).IsGenericType &&
                typeof(TResponse).GetGenericTypeDefinition() == typeof(Result<>))
            {
                // Dynamically create a Result.Failure of the correct type
                return (TResponse)typeof(TResponse)
                    .GetMethod("Failure")!
                    .Invoke(null, [firstError])!;
            }
        }

        return await next();
    }
}
