using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models;

[Table("employees")]
public class EmployeeDal
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("firstName")]
    public string? FirstName { get; set; }

    [Column("lastName")]
    public string? LastName { get; set; }

    [Column("salaryDetails", TypeName = "jsonb")]
    public SalaryDetailsDal SalaryDetails { get; set; } = null!;

    [Column("dateOfBirth")]
    public DateTime DateOfBirth { get; set; }

    [Column("version")]
    public long Version { get; set; }

    // we can store in independent table
    [Column("dependents", TypeName = "jsonb")]
    public DependentDal[] Dependents { get; set; } = null!;

    [Column("changedAt")]
    public DateTime ChangedAt { get; set; }
}