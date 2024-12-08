using System.Text.Json.Serialization;

namespace DAL.Models;

public class SalaryDetailsDal
{
    [JsonPropertyName("amount")]
    public decimal Amount { get; set; }

    [JsonPropertyName("currencyCode")]
    public string CurrencyCode { get; set; } = null!;
}