
using ClassScheduler.Application.Contracts.PersonDtos;
using ClassScheduler.Application.Contracts.RequestDtos.DepartmentRequestDtos;

namespace ClassScheduler.Application.Contracts.RequestDtos.StudentRequestDts;
public record StudentRequestDto : PersonRequestDto
{
    public ICollection<Guid>? DepartmentIds { get; set; }
}