using ClassScheduler.Domain.Model.Entities.Base;

namespace ClassScheduler.Domain.Model.Entities;
public class Course : BaseAuditableEntity
{
    public required string Name { get; set; }
    public required string Code { get; set; }
    public int CreditHour { get; set; }
    public int ECTS { get; set; }
    public int LabHour { get; set; }
    public int LectureHour { get; set; }

    // References
        
    public Guid DeptBatchId { get; set; }
    public DeptBatch? DeptBatch { get; set; }
    public ICollection<Instructor> Instructors { get; set; } = [];
    public ICollection<Student> Students { get; set; } = [];
    public ICollection<Course> Courses { get; set; } = [];
}