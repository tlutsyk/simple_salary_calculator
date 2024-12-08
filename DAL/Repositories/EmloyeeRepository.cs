using System.Collections.Concurrent;
using CSharpFunctionalExtensions;
using Domain.Employee;
using Domain.Employee.ValueObjects;
using MediatR;

namespace DAL.Repositories;

public class DependentRepositoryMock : IEmployeeRepository, IEmployeeQueryRepository,
    IRequestHandler<GetDependentByFilterRequest, Dependent[]>, // todo: should be in separated class by cause I use ,mock it's here
    IRequestHandler<GetDependentByIdRequest, Maybe<Dependent>>
{
    // don't have time to implement real ef core here;
    private static readonly ConcurrentDictionary<EmployeeId, Employee> DbContext = new(MockedData.Employees.ToDictionary(k => k.Id, v => v));
    
    public Task<Maybe<Employee>> GetById(EmployeeId id, CancellationToken cancellationToken)
    {
        if (!DbContext.TryGetValue(id, out var model))
            return Task.FromResult(Maybe<Employee>.None);

        // var model = dal.ToDomain();
        return Task.FromResult(model.AsMaybe());
    }

    public Task Create(Employee employee, CancellationToken cancellationToken)
    {
        // (instead of using debezium) store domain events in outbox table in the same transaction;
        var events = employee.GetAndRemoveEvents();

       // var employeeDal = employee.ToDal();
        DbContext.TryAdd(employee.Id, employee);
        
        return Task.CompletedTask;
    }

    public Task Update(Employee employee, CancellationToken cancellationToken)
    {
        if  (!DbContext.TryGetValue(employee.Id, out var oldValue))
            return Task.CompletedTask;

        // (instead of using debezium) store domain events in outbox table in the same transaction;
        var events = employee.GetAndRemoveEvents();
        //var employeeDal = employee.ToDal();

        DbContext.TryUpdate(employee.Id, employee,  oldValue);

        return Task.CompletedTask;
    }

    Task<Employee[]> IEmployeeQueryRepository.GetByFilters(CancellationToken cancellationToken)
    {
        var employee = DbContext.Values.ToArray();
        return Task.FromResult(employee);
    }

    public Task<Dependent[]> Handle(GetDependentByFilterRequest request, CancellationToken cancellationToken)
    {
        return Task.FromResult(DbContext.Values.SelectMany(v => v.DependentCollections.Dependents).ToArray());
    }

    public Task<Maybe<Dependent>> Handle(GetDependentByIdRequest request, CancellationToken cancellationToken)
    {
        var dependent = DbContext.Values
            .SelectMany(e => e.DependentCollections.Dependents)
            .FirstOrDefault(d => d.Id == request.DependentId);

        return Task.FromResult(dependent.AsMaybe());
    }
}

// todo: Do we really need cause seems we can accesses via employee ?
public record GetDependentByFilterRequest : IRequest<Dependent[]>;
public record GetDependentByIdRequest(int DependentId) : IRequest<Maybe<Dependent>>;