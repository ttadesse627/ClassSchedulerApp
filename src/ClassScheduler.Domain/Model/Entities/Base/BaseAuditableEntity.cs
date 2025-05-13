

namespace ClassScheduler.Domain.Model.Entities.Base;
public class BaseAuditableEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime ModifiedDate { get; set; }
    public string? CreatedUser { get; set; }
    public string? ModifiedUser { get; set; }
}