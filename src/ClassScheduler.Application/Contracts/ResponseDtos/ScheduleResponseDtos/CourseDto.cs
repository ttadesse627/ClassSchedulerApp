namespace ClassScheduler.Application.Contracts.ResponseDtos.ScheduleResponseDtos;
public record CourseDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? CourseCode { get; set; }
    public int CreditHours { get; set; }
}