namespace Domain.Calculator;

public record Paycheck(
    decimal GrossPay,
    decimal NetPay,
    decimal TotalDeductions);