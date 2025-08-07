using ClassScheduler.Application.Contracts.PersonDtos;

namespace ClassScheduler.Application.Contracts.RequestDtos.InstructorRequestDtos;
public record InstructorRequestDto : PersonRequestDto
{
    public ICollection<Guid> CourseIds { get; set; } = [];
}