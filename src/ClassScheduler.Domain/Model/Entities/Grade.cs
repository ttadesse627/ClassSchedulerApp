using ClassScheduler.Domain.Model.Entities.Base;

namespace ClassScheduler.Domain.Model.Entities;
public class Grade: BaseAuditableEntity
{
    public required string Name { get; set; }
    public decimal StartMark { get; set; }
    public decimal EndMark { get; set; }
}