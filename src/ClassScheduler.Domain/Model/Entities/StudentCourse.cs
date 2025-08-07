using ClassScheduler.Domain.Model.Entities.Base;

namespace ClassScheduler.Domain.Model.Entities;
public class StudentCourse: BaseAuditableEntity
{
    public decimal Quiz { get; set; }
    public decimal Test { get; set; }
    public decimal MidExam { get; set; }
    public decimal AssignmentExam { get; set; }
    public decimal FinalExam { get; set; }
    public string? Remark { get; set; }

    public Guid StudentId { get; set; }
    public Student Student { get; set; }
    public Guid CourseId { get; set; }
    public Course Course { get; set; }
    public Guid GradeId { get; set; }
    public Grade Grade { get; set; }
}