

using ClassScheduler.Application.Contracts.RequestDtos.CourseRequestDtos;

namespace ClassScheduler.Application.Contracts.RequestDtos.DepartmentRequestDtos;
public record DepartmentRequestDto
{
    public required string Name { get; set; }
    public required string ShortName { get; set; }
    public int NumberOfSemisters { get; set; }
    public int CurrentSemister { get; set; }
    public ICollection<CourseRequestDto>? Courses { get; set; }
}