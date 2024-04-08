using ClassScheduler.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassScheduler.Domain.Configurations;
public class RolePermissionEntityConfig : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        builder.HasKey(rp => new { rp.RoleId, rp.PermissionId });
        
        builder.HasOne(rp => rp.Permission)
        .WithMany(p => p.RolePermissions)
        .HasForeignKey(rp => rp.PermissionId);

        builder.HasOne(rp => rp.Role)
        .WithMany(p => p.RolePermissions)
        .HasForeignKey(rp => rp.RoleId);

    }
}