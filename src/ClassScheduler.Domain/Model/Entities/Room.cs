

using ClassScheduler.Domain.Model.Entities.Base;
using ClassScheduler.Domain.Model.Enums;

namespace ClassScheduler.Domain.Model.Entities;
public class Room : BaseAuditableEntity
{
    public string RoomNumber { get; set; } = null!;
    public string BlockNumber { get; set; } = null!;
    public RoomType RoomType { get; set; }
    public bool IsAvailable { get; set; }

// References
}