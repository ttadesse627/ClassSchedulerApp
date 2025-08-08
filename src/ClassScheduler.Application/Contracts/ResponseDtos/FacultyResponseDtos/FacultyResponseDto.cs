using ClassScheduler.Application.Contracts.ResponseDtos.CampusResponseDtos;
namespace ClassScheduler.Application.Contracts.ResponseDtos.FacultyResponseDtos;
public record FacultyResponseDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public CampusResponseDto? Campus { get; set; }
}