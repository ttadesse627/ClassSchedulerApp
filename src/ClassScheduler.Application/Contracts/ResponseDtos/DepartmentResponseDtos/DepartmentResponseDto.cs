using ClassScheduler.Application.Contracts.ResponseDtos.CourseResponseDtos;


namespace ClassScheduler.Application.Contracts.ResponseDtos.DepartmentResponseDtos;
public record DepartmentResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string ShortName { get; set; } = null!;
    public int NumberOfSemisters { get; set; }
    public int CurrentSemister { get; set; }
    public ICollection<CourseResponseDto>? Courses { get; set; }
}