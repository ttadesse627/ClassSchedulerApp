

using ClassScheduler.Domain.Model.Enums;

namespace ClassScheduler.Application.Contracts.RequestDtos.RoleRequestDtos;
public record PermissionRequest
{
    public required string Name { get; set; }
    public IList<PermissionEnum> Actions { get; set; } = [];
}