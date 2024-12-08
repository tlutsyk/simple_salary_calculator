using Domain.Employee.ValueObjects;

namespace Domain.Calculator;

public class PaycheckCalculator : IPaycheckCalculator
{
    // todo: Easy to cover with unit test cause the service doesn't have side effects
    public Paycheck CalculatePaycheck(DateTime atTime, Employee.Employee employee, PaycheckDetails details)
    {
        // Base cost for employee
        var totalDeductions = TotalDeductions.Empty
            .Then(deduction => AddBaseCostPerPaycheck(deduction, details))
            .Then(deduction => AddDependentsCost(deduction, employee.DependentCollections, details))
            .Then(deduction => AddOldDependentsCost(atTime, deduction, employee.DependentCollections, details))
            .Then(deduction => IncludeCostForHighSalary(deduction, employee.SalaryDetails, details));
        
        var grossPay = employee.SalaryDetails.AnnualSalary.Value / details.PaychecksPerYear;
        var netPay = grossPay - totalDeductions.Value;

        return new Paycheck(grossPay, netPay, totalDeductions.Value);
    }
    
    internal static TotalDeductions IncludeCostForHighSalary(
        TotalDeductions totalDeductions,
        SalaryDetails salaryDetails,
        PaycheckDetails details)
    {
        var annualSalary = salaryDetails.AnnualSalary.Value;
        var additionalCostForHighSalary = annualSalary > details.HighSalaryThreshold
            ? (annualSalary * details.AdditionalSalaryCostPercentage) / details.PaychecksPerYear
            : 0;

        return new TotalDeductions(totalDeductions.Value + additionalCostForHighSalary);
    }

    internal static TotalDeductions AddBaseCostPerPaycheck(TotalDeductions totalDeductions, PaycheckDetails details)
    {
        var baseCostPerPaycheck = (details.BaseCostPerMonth * 12) / details.PaychecksPerYear;
        return new TotalDeductions(totalDeductions.Value + baseCostPerPaycheck);
    }

    internal static TotalDeductions AddDependentsCost(
        TotalDeductions totalDeductions,
        DependentCollection dependentCollection,
        PaycheckDetails details)
    {
        var cost = (details.DependentCostPerMonth * 12) / details.PaychecksPerYear;
        var totalCost = cost * dependentCollection.Dependents.Length;
        
        return new TotalDeductions(totalDeductions.Value + totalCost);
    }
    
    internal static TotalDeductions AddOldDependentsCost(
        DateTime atTime,
        TotalDeductions totalDeductions,
        DependentCollection dependentCollection,
        PaycheckDetails details)
    {
        var cost = (details.AdditionalCostForDependentsOver50PerMonth * 12) / details.PaychecksPerYear;
        var oldDependentCount = dependentCollection.Dependents
            .Count(d => d.GetAge(atTime) > 50);
        
        var totalOldDependentCost = oldDependentCount * cost;
        
        return new TotalDeductions(totalDeductions.Value + totalOldDependentCost);
    }
}