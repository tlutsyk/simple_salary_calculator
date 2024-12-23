﻿using System.Text.Json.Serialization;
using Api.Dtos.Dependent;

namespace Api.Dtos.Employee;

public class EmployeeDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("firstName")]
    public string? FirstName { get; set; }

    [JsonPropertyName("lastName")]
    public string? LastName { get; set; }

    [JsonPropertyName("salary")]
    public decimal Salary { get; set; }

    [JsonPropertyName("dateOfBirth")]
    public DateTime DateOfBirth { get; set; }

    [JsonPropertyName("dependents")]
    public DependentDto[] Dependents { get; set; } = null!;
}
