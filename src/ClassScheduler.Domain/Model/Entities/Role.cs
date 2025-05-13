using Microsoft.AspNetCore.Identity;

namespace ClassScheduler.Domain.Model.Entities;
public class Role : IdentityRole
{
    public ICollection<Permission> Permissions { get; set; } = [];
    public ICollection<RolePermission> RolePermissions { get; set; } = [];
    public ICollection<UserRole> UserRoles { get; set; } = [];
    public ICollection<User> Users { get; set; } = [];
}