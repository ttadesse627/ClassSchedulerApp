

using ClassScheduler.Domain.Model.Entities.Base;

namespace ClassScheduler.Domain.Model.Entities;
public class Department : BaseAuditableEntity
{
    public required string Name { get; set; }
    public required string Code { get; set; }
    public int NumberOfSemisters { get; set; }
    public Guid FacultyId { get; set; }
    public Faculty? Faculty { get; set; }
}