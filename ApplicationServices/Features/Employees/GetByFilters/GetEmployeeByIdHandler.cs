using Domain.Employee;
using MediatR;

namespace ApplicationServices.Features.Employees.GetByFilters;

// wrap Employee[] with object, add pagination's;
public record GetEmployeeByFilters : IRequest<Employee[]>;

public class GetEmployeeByIdHandler(IEmployeeQueryRepository repository) : IRequestHandler<GetEmployeeByFilters, Domain.Employee.Employee[]>
{
    public Task<Employee[]> Handle(GetEmployeeByFilters request, CancellationToken cancellationToken)
    {
        return repository.GetByFilters(cancellationToken);
    }
}