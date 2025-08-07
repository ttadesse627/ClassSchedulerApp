namespace ClassScheduler.Application.Contracts.ResponseDtos.ScheduleResponseDtos;
public record TimeSlotDto
{
    public Guid Id { get; set; }
    public string? Day { get; set; }
    public string? Time { get; set; }
}