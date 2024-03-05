

using ClassScheduler.Domain.Model.Enums;

namespace ClassScheduler.Domain.Model.Entities;
public class Permission
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public ICollection<PermissionEnum> Permissions { get; set; } = [];
    public ICollection<Role>? Roles { get; set; }
}