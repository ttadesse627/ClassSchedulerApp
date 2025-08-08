

using ClassScheduler.Application.Contracts.RequestDtos.CourseRequestDtos;

namespace ClassScheduler.Application.Contracts.RequestDtos.DepartmentRequestDtos;
public record DepartmentRequestDto
{
    public required string Name { get; set; }
    public required string Code { get; set; }
    public int NumberOfSemisters { get; set; }
    public Guid FacultyId { get; set; }
}