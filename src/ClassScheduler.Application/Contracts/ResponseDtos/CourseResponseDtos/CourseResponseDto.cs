

namespace ClassScheduler.Application.Contracts.ResponseDtos.CourseResponseDtos;
public record CourseResponseDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? CourseCode { get; set; }
    public int CreditHours { get; set; }
    public int ECTS { get; set; }
    public string? DepartmentName { get; set; }
}