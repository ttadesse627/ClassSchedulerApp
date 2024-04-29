using ClassScheduler.Domain.Model.Enums;

namespace ClassScheduler.Application.Contracts.ResponseDtos.RoleDtos;
public record PermissionDto
{
    public string? Name { get; set; }
    public ICollection<PermissionEnum> Actions { get; set; } = [];
}