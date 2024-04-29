using ClassScheduler.Application.Contracts.PersonInfoDtos;

namespace ClassScheduler.Application.Contracts.RequestDtos.InstructorRequestDtos;
public record InstructorRequestDto : PersonInfoRequestDto
{
    public ICollection<Guid> CourseIds { get; set; } = [];
}