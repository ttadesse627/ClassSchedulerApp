namespace ClassScheduler.Application.Contracts.ResponseDtos.ExamResponseDtos;
public record ExamResponseDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public double OutOf { get; set; }
    public string? Remark { get; set; }
}