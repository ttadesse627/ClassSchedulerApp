
namespace ClassScheduler.Application.Contracts.RequestDtos.RoleRequestDtos;
public record CreateRoleRequest
{
    public string Name { get; set; } = string.Empty;
    public ICollection<CreatePermissionRequest> Permissions { get; set; } = [];
}