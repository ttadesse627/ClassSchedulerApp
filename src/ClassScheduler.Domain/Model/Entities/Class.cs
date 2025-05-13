namespace ClassScheduler.Domain.Model.Entities;
public class Class
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid CourseId { get; set; }
    public required Course Course { get; set; }
    public Guid RoomId { get; set; }
    public required Room Room { get; set; }
    public Guid DepartmentId { get; set; }
    public required Department Department { get; set; }
    public Guid TimePeriodId { get; set; }
    public required TimePeriod TimePeriod { get; set; }
    public required Instructor Instructor { get; set; }
    public ICollection<Student> Students { get; set; } = [];
}
