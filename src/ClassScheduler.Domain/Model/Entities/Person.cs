using ClassScheduler.Domain.Model.Entities.Base;

namespace ClassScheduler.Domain.Model.Entities;
public class Person: BaseAuditableEntity
{
    public required string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    public DateTime BirthDate { get; set; }

    // Navigation Properties
    public User? User { get; set; }
    public Instructor? Instructor { get; set; }
    public Student? Student { get; set; }
}