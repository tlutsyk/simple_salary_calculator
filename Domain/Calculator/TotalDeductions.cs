namespace Domain.Calculator;


public record TotalDeductions(decimal Value)
{
    public static TotalDeductions Empty { get; } = new(0);
}