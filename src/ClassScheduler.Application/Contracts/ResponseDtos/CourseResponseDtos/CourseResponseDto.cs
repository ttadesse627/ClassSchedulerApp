

namespace ClassScheduler.Application.Contracts.ResponseDtos.CourseResponseDtos;
public record CourseResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string CourseCode { get; set; } = string.Empty;
    public int CreditHours { get; set; }
    public int ECTS { get; set; }
}