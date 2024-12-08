using System.Text.Json.Serialization;

namespace Api.Dtos.Employee;

public class EmployeeListDto
{
    [JsonPropertyName("items")]
    public required EmployeeDto[] Employees { get; init; } = null!;

    [JsonPropertyName("page")]
    public required  int Page { get; init; }
}