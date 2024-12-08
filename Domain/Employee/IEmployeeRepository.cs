using CSharpFunctionalExtensions;
using Domain.Employee.ValueObjects;

namespace Domain.Employee;

public interface IEmployeeRepository
{
    Task<Maybe<Employee>> GetById(EmployeeId id, CancellationToken cancellationToken);

    Task Create(Employee id, CancellationToken cancellationToken);

    Task Update(Employee id, CancellationToken cancellationToken);
}