using DAL.Models;
using Domain.Employee;

namespace DAL.Converters;

internal static class EmployeeConverter
{
    internal static Employee ToDomain(this EmployeeDal dal)
    {
        throw new NotImplementedException();
    }

    internal static EmployeeDal ToDal(this Employee domain)
    {
        throw new NotImplementedException();
    }
}