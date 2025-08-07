namespace ClassScheduler.Application.Features.Courses.Command.Create;
public record CreateCourseRequest
{
    public required string Name { get; set; }
    public required string Code { get; set; }
    public int CreditHour { get; set; }
    public int ECTS { get; set; }
    public int LabHour { get; set; }
    public int LectureHour { get; set; }
}