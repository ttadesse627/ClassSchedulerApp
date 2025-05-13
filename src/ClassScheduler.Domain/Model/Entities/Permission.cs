using ClassScheduler.Domain.Model.Enums;

namespace ClassScheduler.Domain.Model.Entities;
public class Permission
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public IList<PermissionEnum> Actions { get; set; } = [];
    public ICollection<RolePermission> RolePermissions { get; set; } = [];
}