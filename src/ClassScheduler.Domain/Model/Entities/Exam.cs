

using ClassScheduler.Domain.Model.Entities.Base;

namespace ClassScheduler.Domain.Model.Entities;
public class Exam: BaseAuditableEntity
{
    public required string Name { get; set; }
    public required double OutOf { get; set; }
    public string? Remark { get; set; }
    
}