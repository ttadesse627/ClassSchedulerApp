namespace ClassScheduler.Application.Contracts.ResponseDtos.ScheduleResponseDtos;
public record DepartmentClassesDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? ShortName { get; set; }
    public ICollection<DayGroupDto> DayGroups { get; set; } = [];
}