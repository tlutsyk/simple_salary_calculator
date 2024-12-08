namespace Domain.Employee;

// todo: Use query model instead of domain models;
// we can use derect
public interface IEmployeeQueryRepository
{
    // todo: Add filters with pagination;
    Task<Employee[]> GetByFilters(CancellationToken cancellationToken);
}