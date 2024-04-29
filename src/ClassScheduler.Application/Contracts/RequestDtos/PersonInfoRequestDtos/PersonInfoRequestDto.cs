

namespace ClassScheduler.Application.Contracts.PersonInfoDtos;
public record PersonInfoRequestDto
{
    public required string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public required string LastName { get; set; }
    public DateTime BirthDate { get; set; }
}