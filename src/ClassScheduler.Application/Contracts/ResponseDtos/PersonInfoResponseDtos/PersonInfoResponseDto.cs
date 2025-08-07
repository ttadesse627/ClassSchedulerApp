

namespace ClassScheduler.Application.Contracts.ResponseDtos.PersonDtos;
public record PersonResponseDto
{
    public string FirstName { get; set; } = null!;
    public string MiddleName { get; set; } = null!;
    public string? LastName { get; set; }
    public DateTime BirthDate { get; set; }
}