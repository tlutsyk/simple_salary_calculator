using Version = Domain.Shared.Version;

namespace Domain.Shared;

public abstract record DomainEvent
{
    protected DomainEvent(Version version, DateTimeOffset occurredAt)
    {
        ArgumentNullException.ThrowIfNull(version);

        Version = version;
        OccurredAt = occurredAt;
    }

    public Version Version { get; }

    public DateTimeOffset OccurredAt { get; }
}