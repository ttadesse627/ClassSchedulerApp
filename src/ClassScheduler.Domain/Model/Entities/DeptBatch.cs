namespace ClassScheduler.Domain.Model.Entities;

public class DeptBatch
{
    public Guid Id {get; set; } = Guid.NewGuid();
    public string? Name { get; set; }
    public Guid DepartmentId {get; set;}
    public required Department Department { get; set; }
    public ICollection<Section> Sections { get; set; } = [];
    public ICollection<Course> Courses { get; set; } = [];
    public ICollection<Student> Students { get; set; } = [];
}