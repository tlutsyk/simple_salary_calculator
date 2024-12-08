namespace Domain.Employee.ValueObjects;

public record EmployeeId(int Value) : IComparable<EmployeeId>
{
    public int CompareTo(EmployeeId? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        return other is null ? 1 : Value.CompareTo(other.Value);
    }
}