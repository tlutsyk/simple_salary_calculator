using Api.Dtos.Dependent;
using Api.Dtos.Employee;
using Domain.Calculator;
using Domain.Employee;

namespace Api.Converters;

internal static class EmployeesConverter
{
    internal static DependentDto ToDto(this Dependent dependent)
    {
        return new DependentDto
        {
            Id = dependent.Id,
            FirstName = dependent.FirstName,
            LastName = dependent.LastName,
            DateOfBirth = dependent.DateOfBirth,
            Relationship = dependent.Relationship.ToString("G"),
        };
    }

    internal static EmployeeDto ToDto(this Employee employee) =>
        new()
        {
            Id = employee.Id.Value,
            FirstName = employee.FirstName.GetValueOrDefault(),
            LastName = employee.LastName.GetValueOrDefault(),
            Salary = employee.SalaryDetails.AnnualSalary.Value,
            DateOfBirth = employee.DateOfBirth,
            Dependents = employee.DependentCollections.Dependents
                .Select(d => d.ToDto())
                .ToArray(),
        };

    internal static EmployeeListDto ToDto(this Employee[] employees)
    {
        return new EmployeeListDto
        {
            Employees = employees
                .Select(employee => employee.ToDto())
                .ToArray(),
            Page = 0 // add real pagination
        };
    }

    internal static PaycheckDto ToDto(this Paycheck paycheck)
        => new()
        {
            NetPay = paycheck.GrossPay,
            GrossPay = paycheck.NetPay,
            TotalDeductions = paycheck.TotalDeductions
        };
}