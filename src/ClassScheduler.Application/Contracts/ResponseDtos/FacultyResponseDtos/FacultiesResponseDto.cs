namespace ClassScheduler.Application.Contracts.ResponseDtos.FacultyResponseDtos;
public record FacultiesResponseDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Campus { get; set; }
}