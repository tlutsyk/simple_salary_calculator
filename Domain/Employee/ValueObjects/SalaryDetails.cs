namespace Domain.Employee.ValueObjects;

public record SalaryDetails
{
    public SalaryDetails(SalaryAmount annualSalary, CurrencyCode currencyCode)
    {
        ArgumentNullException.ThrowIfNull(annualSalary);
        ArgumentNullException.ThrowIfNull(currencyCode);
        
        AnnualSalary = annualSalary;
        CurrencyCode = currencyCode;
    }

    public SalaryAmount AnnualSalary { get; }

    public CurrencyCode CurrencyCode { get; }
}