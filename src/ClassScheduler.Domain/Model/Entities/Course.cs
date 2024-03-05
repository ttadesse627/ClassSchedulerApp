

using ClassScheduler.Domain.Model.Entities.Base;

namespace ClassScheduler.Domain.Model.Entities;
public class Course : BaseAuditableEntity
{
    public string Name { get; set; } = null!;
    public string CourseCode { get; set; } = null!;
    public int CreditHours { get; set; }
    public int ECTS { get; set; }

    // References
    public Guid DepatmentId { get; set; }
    public Department? Department { get; set; }
    public ICollection<Instructor>? Instructors { get; set; }
    public ICollection<Student>? Students { get; set; }
}