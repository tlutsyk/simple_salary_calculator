using CSharpFunctionalExtensions;
using Domain.Calculator;
using Domain.Employee;
using Domain.Employee.ValueObjects;
using MediatR;

namespace ApplicationServices.Features.Employees.GetCurrentSalary;

public record GetEmployeePaycheckRequest(EmployeeId EmployeeId, DateTime AtTime) : IRequest<Result<Paycheck>>;

public class GetCurrentSalaryHandler : IRequestHandler<GetEmployeePaycheckRequest, Result<Paycheck>>
{
    private readonly IEmployeeRepository _repository;
    private readonly IPaycheckCalculator _calculator;
    // todo: retrieve from repository (etc);
    private readonly PaycheckDetails PaycheckDetails = new(); 

    public GetCurrentSalaryHandler(IEmployeeRepository repository, IPaycheckCalculator calculator)
    {
        _repository = repository;
        _calculator = calculator;
    }

    public async Task<Result<Paycheck>> Handle(GetEmployeePaycheckRequest request, CancellationToken cancellationToken)
    {
        var maybeEmployee = await _repository.GetById(request.EmployeeId, cancellationToken);
        if (maybeEmployee.HasNoValue)
        {
            return Result.Failure<Paycheck>($"{nameof(Employee)} not found");
        }

        // todo: Here we can use diff strategies;
        var paycheck = _calculator.CalculatePaycheck(
            request.AtTime,
            maybeEmployee.Value,
            PaycheckDetails);
        
        return paycheck;
    }
}