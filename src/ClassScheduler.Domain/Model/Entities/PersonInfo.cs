

namespace ClassScheduler.Domain.Model.Entities;
public class PersonInfo
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public required string LastName { get; set; }
    public DateTime BirthDate { get; set; }

    // Navigation Properties
    public User? User { get; set; }
}