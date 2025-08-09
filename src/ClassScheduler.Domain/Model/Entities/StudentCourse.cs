using ClassScheduler.Domain.Model.Entities.Base;

namespace ClassScheduler.Domain.Model.Entities;
public class StudentCourse: BaseAuditableEntity
{
    public Guid StudentId { get; set; }
    public required Student Student { get; set; }
    public Guid CourseId { get; set; }
    public required Course Course { get; set; }
    public Guid? ExamId { get; set; }
    public Grade? Exam { get; set; }
    public Guid? GradeId { get; set; }
    public Grade? Grade { get; set; }
}