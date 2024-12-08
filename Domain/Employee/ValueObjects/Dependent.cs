public record Dependent
{
    // add ctorf with validation;
    public required int Id { get; init; }

    public required string? FirstName { get; init; }

    public required string? LastName { get; init; }

    public required DateTime DateOfBirth { get; init; }

    public required Relationship Relationship { get; init; }
    
    public int GetAge(DateTime atTime)
    {
        if (atTime < DateOfBirth)
            throw new ArgumentException("Date of birth must be greater than or equal to dateOfBirth");
        
        return atTime.Year - DateOfBirth.Year;
    }
}

public enum Relationship
{
    None,
    Spouse,
    DomesticPartner,
    Child
}
