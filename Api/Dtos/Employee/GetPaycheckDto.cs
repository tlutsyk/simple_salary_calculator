using System.Text.Json.Serialization;

namespace Api.Dtos.Employee;

public class GetPaycheckDto
{
    [JsonPropertyName("atTime")]
    public DateTime AtTime { get; init; }
}