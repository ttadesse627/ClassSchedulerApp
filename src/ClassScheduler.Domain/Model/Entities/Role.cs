using Microsoft.AspNetCore.Identity;

namespace ClassScheduler.Domain.Model.Entities;
public class Role : IdentityRole
{
#pragma warning disable CS0114 // Member hides inherited member; missing override keyword
    public string Name { get; set; } = string.Empty;
#pragma warning restore CS0114 // Member hides inherited member; missing override keyword
    public ICollection<Permission> Permissions { get; set; } = [];
    public ICollection<RolePermission> RolePermissions { get; set; } = [];
    public ICollection<UserRole> UserRoles { get; set; } = [];
    public ICollection<User> Users { get; set; } = [];
}