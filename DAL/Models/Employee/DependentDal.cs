using System.Text.Json.Serialization;

namespace DAL.Models;

public class DependentDal
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("firstName")]
    public string? FirstName { get; set; }

    [JsonPropertyName("lastName")]
    public string? LastName { get; set; }

    [JsonPropertyName("birthDate")]
    public DateTime DateOfBirth { get; set; }

    [JsonPropertyName("relationship")]
    public RelationshipEnumDal RelationshipEnum { get; set; }
}