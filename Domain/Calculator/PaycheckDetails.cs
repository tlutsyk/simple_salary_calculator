namespace Domain.Calculator;

public record PaycheckDetails
{
    public decimal BaseCostPerMonth = 1000m;
    public decimal DependentCostPerMonth = 600m;
    public decimal AdditionalCostForDependentsOver50PerMonth = 200m;
    public decimal HighSalaryThreshold = 80000m;
    public decimal AdditionalSalaryCostPercentage = 0.02m;
    public int PaychecksPerYear = 26;
}