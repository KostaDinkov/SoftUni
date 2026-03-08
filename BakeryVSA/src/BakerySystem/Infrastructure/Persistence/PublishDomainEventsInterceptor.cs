using BakerySystem.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BakerySystem.Infrastructure.Persistence;

public sealed class PublishDomainEventsInterceptor(IPublisher publisher) : SaveChangesInterceptor
{
    // ✅ Use SavedChangesAsync (past tense) — fires only after successful commit
    public override async ValueTask<int> SavedChangesAsync(
        SaveChangesCompletedEventData eventData,
        int result,
        CancellationToken ct = default)
    {
        await PublishDomainEvents(eventData.Context, ct);
        return await base.SavedChangesAsync(eventData, result, ct);
    }

    private async Task PublishDomainEvents(DbContext? context, CancellationToken ct)
    {
        if (context is null) return;

        var entitiesWithEvents = context.ChangeTracker.Entries<Entity>()
            .Select(e => e.Entity)
            .Where(e => e.DomainEvents.Any())
            .ToList();

        var domainEvents = entitiesWithEvents
            .SelectMany(e => e.DomainEvents)
            .ToList();

        entitiesWithEvents.ForEach(e => e.ClearDomainEvents());

        foreach (var domainEvent in domainEvents)
            await publisher.Publish(domainEvent, ct);
    }
}