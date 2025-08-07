using ClassScheduler.Domain.Model.Entities.Base;

namespace ClassScheduler.Domain.Model.Entities;
public class Section: BaseAuditableEntity
{
    public string? Name { get; set; }
    public Guid DeptBatchId { get; set; }
    public DeptBatch? DeptBatch { get; set; }
    public ICollection<Student>? Students { get; set; } = [];
    public int NumberOfStudents { get; set; }
}
