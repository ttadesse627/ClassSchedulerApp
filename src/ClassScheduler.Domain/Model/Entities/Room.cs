using ClassScheduler.Domain.Model.Entities.Base;
using ClassScheduler.Domain.Model.Enums;

namespace ClassScheduler.Domain.Model.Entities;
public class Room : BaseAuditableEntity
{
    public required string Code { get; set; }
    public RoomType RoomType { get; set; }
    public bool IsAvailable { get; set; } = true;
    public ICollection<DeptBatch> DeptBatches { get; set; } = [];
}