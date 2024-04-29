namespace ClassScheduler.Application.Contracts.ResponseDtos.ScheduleResponseDtos;
public record RoomDto
{
    public Guid Id { get; set; }
    public string? RoomName { get; set; }
}