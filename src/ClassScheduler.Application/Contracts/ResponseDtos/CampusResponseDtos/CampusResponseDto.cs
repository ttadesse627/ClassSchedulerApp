using ClassScheduler.Application.Contracts.ResponseDtos.DepartmentResponseDtos;
using ClassScheduler.Application.Contracts.ResponseDtos.PersonDtos;


namespace ClassScheduler.Application.Contracts.ResponseDtos.CampusResponseDtos;
public record CampusResponseDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}