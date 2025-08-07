

using ClassScheduler.Domain.Model.Entities.Base;

namespace ClassScheduler.Domain.Model.Entities;
public class Department : BaseAuditableEntity
{
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    public int NumberOfSemisters { get; set; }
}