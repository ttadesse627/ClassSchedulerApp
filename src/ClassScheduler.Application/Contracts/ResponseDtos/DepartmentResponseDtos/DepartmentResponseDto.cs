using ClassScheduler.Application.Contracts.ResponseDtos.CourseResponseDtos;


namespace ClassScheduler.Application.Contracts.ResponseDtos.DepartmentResponseDtos;
public record DepartmentResponseDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? ShortName { get; set; }
    public int NumberOfSemisters { get; set; }
    public ICollection<CourseResponseDto> Courses { get; set; } = [];
}