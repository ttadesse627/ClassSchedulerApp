namespace ClassScheduler.Application.Contracts.ResponseDtos.ScheduleResponseDtos;
public record DayGroupDto
{
    public string? Day { get; set; }
    public ICollection<ClassDto> Classes { get; set; } = [];
}