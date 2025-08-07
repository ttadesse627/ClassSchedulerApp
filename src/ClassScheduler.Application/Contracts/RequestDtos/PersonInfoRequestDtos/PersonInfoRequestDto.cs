

namespace ClassScheduler.Application.Contracts.PersonDtos;
public record PersonRequestDto
{
    public required string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public required string LastName { get; set; }
    public DateTime BirthDate { get; set; }
}