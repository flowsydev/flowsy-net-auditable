using Flowsy.Auditable.Test.EventSourcing.Domain.Events;

namespace Flowsy.Auditable.Test.EventSourcing.Domain;

public abstract class AggregateRoot : IAuditable
{
    private readonly List<DomainEvent> _events = [];
    public IEnumerable<DomainEvent> Events => _events;
    
    public long Version { get; private set; }

    public AuditableOperation Creation { get; protected set; } = new();

    public AuditableOperation? LastMutation { get; protected set; }

    public AuditableLifetime Lifetime { get; protected set; } = new();

    protected abstract void Apply(DomainEvent @event);

    protected void ApplyChange(DomainEvent @event)
    {
        Apply(@event);
        _events.Add(@event);
        Version++;
    }
    
    public void Replay(IEnumerable<DomainEvent> events)
    {
        Version = 0;
        foreach (var @event in events)
        {
            Apply(@event);
            Version++;
        }
    }
    
    public void Flush() => _events.Clear();
}