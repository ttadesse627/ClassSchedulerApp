

using ClassScheduler.Domain.Model.Enums;

namespace ClassScheduler.Application.Contracts.RequestDtos.RoleRequestDtos;
public record CreatePermissionRequest
{
    public string Name { get; set; } = string.Empty;
    public ICollection<PermissionEnum> Permissions { get; set; } = [];
}