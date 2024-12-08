namespace Domain.Calculator;

internal static class TotalDeductionsExtensions
{
    internal static TotalDeductions Then(this TotalDeductions totalDeductions, Func<TotalDeductions, TotalDeductions> func)
    {
        return func(totalDeductions);
    }
}