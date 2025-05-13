
using ClassScheduler.Application.Contracts.PersonInfoDtos;
using ClassScheduler.Application.Contracts.RequestDtos.DepartmentRequestDtos;

namespace ClassScheduler.Application.Contracts.RequestDtos.StudentRequestDts;
public record StudentRequestDto : PersonInfoRequestDto
{
    public ICollection<Guid>? DepartmentIds { get; set; }
}