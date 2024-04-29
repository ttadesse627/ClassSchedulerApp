using ClassScheduler.Domain.Model.Entities.Base;
using ClassScheduler.Domain.Model.Enums;

namespace ClassScheduler.Domain.Model.Entities;
public class Room : BaseAuditableEntity
{
    public required string RoomNumber { get; set; }
    public string? BlockNumber { get; set; }
    public RoomType RoomType { get; set; }
    public bool IsAvailable { get; set; } = true;
    public ICollection<Department> Departments { get; set; } = [];
}