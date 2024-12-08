using System.Text.Json.Serialization;

namespace Api.Dtos.Employee;

public class PaycheckDto
{
    [JsonPropertyName("netPay")]
    public decimal NetPay { get; set; }

    [JsonPropertyName("grossPay")]
    public decimal GrossPay { get; set; }

    [JsonPropertyName("totalDeductions")]
    public decimal TotalDeductions { get; set; }
}