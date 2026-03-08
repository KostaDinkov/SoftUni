using BakerySystem.Domain.Common;
using FluentValidation;
using MediatR;
using System.Reflection;

namespace BakerySystem.Infrastructure.MediatR;

public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken ct)
    {
        if (!validators.Any()) return await next();

        var context = new ValidationContext<TRequest>(request);
        var validationResults = await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, ct)));

        var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

        if (failures.Count != 0)
        {
            var errors = failures
                .GroupBy(e => e.PropertyName)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(e => e.ErrorMessage).Distinct().ToArray()
                );

            var errorRecord = Error.ValidationError(errors);

            // Here we check if TResponse is actually a Result type
            // This assumes you have a way to create a result from an error.
            if (typeof(TResponse).IsGenericType &&
                typeof(TResponse).GetGenericTypeDefinition() == typeof(Result<>))
            {
                // We use 'Activator' once here to create the Result<T>.Failure
                return (TResponse)Activator.CreateInstance(
                    typeof(TResponse),
                    BindingFlags.Instance | BindingFlags.NonPublic,
                    null,
                    [false, default, errorRecord],
                    null)!;
            }

            throw new ValidationException(failures); // Fallback if not using Result pattern
        }

        return await next();
    }
}