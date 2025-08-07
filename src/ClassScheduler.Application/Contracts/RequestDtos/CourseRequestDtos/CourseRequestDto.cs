

namespace ClassScheduler.Application.Contracts.RequestDtos.CourseRequestDtos;
public record CourseRequestDto
{
    public Guid DepartmentId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public int CreditHour { get; set; }
    public int ECTS { get; set; }
}