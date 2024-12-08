using CSharpFunctionalExtensions;

namespace Domain.Shared;

public abstract class DomainEntity<TId> : Entity<TId>
    where TId : IComparable<TId>
{
    protected DomainEntity(TId id, Version version) : base(id)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));
        Version = version;
        DomainEvents = new List<DomainEvent>();
    }

    public Version Version { get; private set; }

    private List<DomainEvent> DomainEvents { get; }

    public void AddEvent(DomainEvent domainEvent)
    {
        ArgumentNullException.ThrowIfNull(domainEvent, nameof (domainEvent));
        DomainEvents.Add(domainEvent);
    }

    public IReadOnlyCollection<DomainEvent> GetAndRemoveEvents()
    {
        var array = DomainEvents.ToArray();
        DomainEvents.Clear();
        return array;
    }
    
    protected void IncrementVersion() => Version = new(Version.Value + 1L);
}