

namespace ClassScheduler.Application.Contracts.ResponseDtos.ScheduleResponseDtos;
public record ScheduleDto
{
    public int ClassNumber { get; set; }
    public ICollection<DepartmentDto> Departments { get; set; } = [];
}