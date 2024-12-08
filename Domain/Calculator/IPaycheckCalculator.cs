namespace Domain.Calculator;

public interface IPaycheckCalculator
{
    public Paycheck CalculatePaycheck(
        DateTime atTime,
        Employee.Employee employee,
        PaycheckDetails details);
}