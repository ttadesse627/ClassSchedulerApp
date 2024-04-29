namespace ClassScheduler.Application.Contracts.ResponseDtos.ScheduleResponseDtos;
public record ClassDto
{
    public Guid Id { get; set; }
    public CourseDto? Course { get; set; }
    public RoomDto? Room { get; set; }
    public TimePeriodDto? TimePeriod { get; set; }
    public InstructorDto? Instructor { get; set; }
}