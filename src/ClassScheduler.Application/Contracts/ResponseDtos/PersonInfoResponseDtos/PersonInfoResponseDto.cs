

namespace ClassScheduler.Application.Contracts.ResponseDtos.PersonInfoDtos;
public record PersonInfoResponseDto
{
    public string FirstName { get; set; } = null!;
    public string MiddleName { get; set; } = null!;
    public string? LastName { get; set; }
    public DateTime BirthDate { get; set; }
}