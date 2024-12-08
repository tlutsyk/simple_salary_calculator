using CSharpFunctionalExtensions;
using Domain.Employee;
using Domain.Employee.ValueObjects;
using MediatR;

namespace ApplicationServices.Features.Employees.GetById;

public record GetEmployeeById(EmployeeId EmployeeId) : IRequest<Maybe<Employee>>;

public class GetEmployeeByIdHandler(IEmployeeRepository repository) : IRequestHandler<GetEmployeeById, Maybe<Employee>>
{
    public Task<Maybe<Employee>> Handle(GetEmployeeById request, CancellationToken cancellationToken)
    {
        return repository.GetById(request.EmployeeId, cancellationToken);
    }
}