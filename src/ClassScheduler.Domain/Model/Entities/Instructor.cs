using ClassScheduler.Domain.Model.Entities.Base;

namespace ClassScheduler.Domain.Model.Entities;
public class Instructor : BaseAuditableEntity
{
    public string? UserId { get; set; }
    public User? User { get; set; }
    public ICollection<Course> Courses { get; set; } = [];
}