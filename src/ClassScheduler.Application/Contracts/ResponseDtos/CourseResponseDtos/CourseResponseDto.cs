

namespace ClassScheduler.Application.Contracts.ResponseDtos.CourseResponseDtos;
public record CourseResponseDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Code { get; set; }
    public int CreditHour { get; set; }
    public int ECTS { get; set; }
    public string? BatchName { get; set; }
}