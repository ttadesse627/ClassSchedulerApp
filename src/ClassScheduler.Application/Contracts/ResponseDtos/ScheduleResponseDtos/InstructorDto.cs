namespace ClassScheduler.Application.Contracts.ResponseDtos.ScheduleResponseDtos;
public record InstructorDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}