using System.Text.Json.Serialization;
using Api.Models;

namespace Api.Dtos.Dependent;

public class GetDependentDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("firstName")]
    public string? FirstName { get; set; }

    [JsonPropertyName("lastName")]
    public string? LastName { get; set; }

    [JsonPropertyName("dateOfBirth")]
    public DateTime DateOfBirth { get; set; }

    [JsonPropertyName("relationship")]
    public Relationship Relationship { get; set; }
}
