

namespace ClassScheduler.Application.Contracts.PersonInfoDtos;
public record PersonInfoRequestDto
{
    public string FirstName { get; set; } = null!;
    public string MiddleName { get; set; } = null!;
    public string? LastName { get; set; }
    public DateTime BirthDate { get; set; }
}