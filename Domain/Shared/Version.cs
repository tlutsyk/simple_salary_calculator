namespace Domain.Shared;

public sealed record Version
{
    public Version(long value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value));

        Value = value;
    }

    public long Value { get; }
}