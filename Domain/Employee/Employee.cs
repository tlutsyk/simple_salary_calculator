using CSharpFunctionalExtensions;
using Domain.Employee.Events;
using Domain.Employee.ValueObjects;
using Domain.Shared;
using Version = Domain.Shared.Version;

namespace Domain.Employee;

public class Employee : DomainEntity<EmployeeId>
{
    public Employee(
        EmployeeId employeeId,
        Maybe<string> firstName,
        Maybe<string> lastName,
        SalaryDetails salaryDetails,
        DateTime dateOfBirth,
        DependentCollection dependentCollections,
        Version version,
        DateTime changedAt) : base(employeeId, version)
    {
        // We use guards to be sure that domain model we've created is correct;
        ArgumentNullException.ThrowIfNull(salaryDetails);
        ArgumentNullException.ThrowIfNull(dependentCollections);
        ArgumentNullException.ThrowIfNull(version);
        ArgumentNullException.ThrowIfNull(employeeId);
        // also check date of birth;
        
        FirstName = firstName;
        LastName = lastName;
        SalaryDetails = salaryDetails;
        DateOfBirth = dateOfBirth;
        DependentCollections = dependentCollections;
        ChangedAt = changedAt;
    }
    
    // we can use Option<> or nullable types here;
    public Maybe<string> FirstName { get; private set; }

    public Maybe<string> LastName { get; private set; }

    public SalaryDetails SalaryDetails { get; private set; }

    public DateTime DateOfBirth { get; private set; }

    public DependentCollection DependentCollections { get; private set; }

    public DateTime ChangedAt { get; private set; }

    
    public Result UpdateEmployeeDependents(Dependent[] dependents)
    {
        // Add validation business rules here.
        var isNewDependentsCorrect = true;
        if (!isNewDependentsCorrect)
        {
            Result.Failure("Add here some kind of typed error");
        }

        // For optimistic concurrency check in the DB and versioning across the message bus;
        IncrementVersion();
        
        // Add Employee changed event;
        // AddEvent(new EmployeeChangedEvent(Version, ChangedAt));
        
        return Result.Success();
    }
    
    public Result UpdateEmployee(EmployeeData employeeData)
    {
        // if data to update is not correct return failed result;
        
        IncrementVersion();
        
        // Add state into event;
        AddEvent(new EmployeeChangedEvent(Version, ChangedAt));
        return Result.Success();
    }
}

public class EmployeeData(SalaryDetails SalaryDetails);