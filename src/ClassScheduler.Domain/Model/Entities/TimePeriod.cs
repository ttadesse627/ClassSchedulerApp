namespace ClassScheduler.Domain.Model.Entities;
public class TimePeriod
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Day { get; set; } = null!;
    public string StartTime { get; set; } = null!;
    public string EndTime { get; set; } = null!;
}