using ClassScheduler.Domain.Model.Entities.Base;

namespace ClassScheduler.Domain.Model.Entities;
public class Instructor : BaseAuditableEntity
{
    public Guid? PersonId { get; set; }
    public Person? Person { get; set; }
    public ICollection<Course> Courses { get; set; } = [];
}