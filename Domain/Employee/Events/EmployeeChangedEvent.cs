using Domain.Shared;
using Version = Domain.Shared.Version;

namespace Domain.Employee.Events;

// We can use EmployeeChanged event or more specific domain events like
// EmployeeSalaryChanged, EmployeeDependentsChanged, etc. It dependents on update strategy
// form based or command based (Update salary, Update dependents). 
public record EmployeeChangedEvent : DomainEvent
{
    public EmployeeChangedEvent(Version version, DateTimeOffset occurredAt)
        : base(version, occurredAt)
    {
    }
}
