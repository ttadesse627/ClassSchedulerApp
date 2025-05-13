namespace ClassScheduler.Application.Contracts.ResponseDtos.DepartmentResponseDtos;
public record GetForCourseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string ShortName { get; set; } = null!;
}