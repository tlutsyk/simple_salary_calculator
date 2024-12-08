using Domain.Employee;
using Domain.Employee.ValueObjects;
using Version = Domain.Shared.Version;

namespace DAL.Repositories;

public class MockedData
{
    // todo: create fake data via API;
    public static Employee[] Employees { get; } =
    {
        new(
            new EmployeeId(1),
            firstName: "LeBron",
            lastName: "James",
            new SalaryDetails(
                new SalaryAmount(75420.99m),
                new CurrencyCode("USD")),
            dateOfBirth: new DateTime(1984, 12, 30),
            new DependentCollection([]),
            new Version(1),
            changedAt: DateTime.UtcNow),
        new(
            new EmployeeId(2),
            firstName: "Ja",
            lastName: "Morant",
            new SalaryDetails(
                new SalaryAmount(92365.22m),
                new CurrencyCode("USD")),
            new DateTime(1999, 8, 10),
            new DependentCollection(
            [
                new Dependent
                {
                    Id = 1,
                    FirstName = "Spouse",
                    LastName = "Morant",
                    DateOfBirth = new DateTime(1998, 3, 3),
                    Relationship = Relationship.Spouse
                },
                new Dependent
                {
                    Id = 2,
                    FirstName = "Child1",
                    LastName = "Morant",
                    Relationship = Relationship.Child,
                    DateOfBirth = new DateTime(2020, 6, 23)
                },
                new Dependent
                {
                    Id = 3,
                    FirstName = "Child2",
                    LastName = "Morant",
                    Relationship = Relationship.Child,
                    DateOfBirth = new DateTime(2021, 5, 18)
                },
            ]),
            new Version(1),
            changedAt: DateTime.UtcNow),
        new(
            new EmployeeId(3),
            firstName: "Michael",
            lastName: "Jordan",
            new SalaryDetails(
                new SalaryAmount(143211.12m),
                new CurrencyCode("USD")),
            dateOfBirth: new DateTime(1963, 2, 17),
            new DependentCollection(
                Dependents:
                [
                    new Dependent
                    {
                        Id = 4,
                        FirstName = "DP",
                        LastName = "Jordan",
                        Relationship = Relationship.DomesticPartner,
                        DateOfBirth = new DateTime(1974, 1, 2)
                    },
                ]),
            new Version(1),
            changedAt: DateTime.UtcNow),
    };
}