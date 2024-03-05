

using ClassScheduler.Domain.Model.Entities.Base;

namespace ClassScheduler.Domain.Model.Entities;
public class Class : BaseAuditableEntity
{
    public DateTime Time { get; set; }
    public Guid CourseId { get; set; }
    public Guid RoomId { get; set; }
    public int ECTS { get; set; }

    // References
    public Guid DepatmentId { get; set; }
    public Department? Department { get; set; }
    public ICollection<Instructor>? Instructors { get; set; }
    public ICollection<Student>? Students { get; set; }
}
