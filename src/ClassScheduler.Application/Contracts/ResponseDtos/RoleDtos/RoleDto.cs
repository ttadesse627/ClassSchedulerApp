using ClassScheduler.Domain.Model.Entities;

namespace ClassScheduler.Application.Contracts.ResponseDtos.RoleDtos;
public record RoleDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}