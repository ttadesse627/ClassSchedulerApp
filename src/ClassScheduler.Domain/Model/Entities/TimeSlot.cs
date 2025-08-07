using ClassScheduler.Domain.Model.Enums;
namespace ClassScheduler.Domain.Model.Entities;
public class TimeSlot
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public WeekDay Day { get; set; }
    public string StartTime { get; set; } = null!;
    public string EndTime { get; set; } = null!;
}