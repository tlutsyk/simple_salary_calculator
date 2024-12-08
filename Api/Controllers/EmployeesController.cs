using Api.Converters;
using Api.Dtos.Employee;
using ApplicationServices.Features.Employees.GetByFilters;
using ApplicationServices.Features.Employees.GetById;
using ApplicationServices.Features.Employees.GetCurrentSalary;
using CSharpFunctionalExtensions;
using Domain.Employee.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/employees")]
public class EmployeesController(IMediator mediator) : ControllerBase
{
    [HttpPost("{id}/paycheck")]
    [SwaggerOperation(Summary = "Get employee by id")]
    public async Task<ActionResult<PaycheckDto>> Get(int id, GetPaycheckDto dto, CancellationToken cancellationToken)
    {
        var request = new GetEmployeePaycheckRequest(new EmployeeId(id), dto.AtTime);

        var result = await mediator.Send(request, cancellationToken);

        return result.Match(
            onSuccess: paycheck => (ActionResult<PaycheckDto>)Ok(paycheck.ToDto()),
            onFailure: _ => BadRequest()); //  add problem details;
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Get employee by id")]
    public async Task<ActionResult<EmployeeDto>> Get(int id, CancellationToken cancellationToken)
    {
        var request = new GetEmployeeById(new EmployeeId(id));

        var maybeEmployee = await mediator.Send(request, cancellationToken);
        
        return maybeEmployee.Match(
            employee => (ActionResult<EmployeeDto>)Ok(employee.ToDto()),
            () => NotFound());
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Get all employees")]
    // todo: add query filters with pagination's
    public async Task<ActionResult<EmployeeListDto>> GetAll(CancellationToken cancellationToken)
    {
        var request = new GetEmployeeByFilters();
        var response = await mediator.Send(request, cancellationToken);
        
        return Ok(response.ToDto());
    }
}