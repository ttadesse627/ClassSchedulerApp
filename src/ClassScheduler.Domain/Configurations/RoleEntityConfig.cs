using ClassScheduler.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassScheduler.Domain.Configurations;
public class RoleEntityConfig : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(role => role.Id);

        builder.HasMany(role => role.Permissions)
            .WithMany()
            .UsingEntity<RolePermission>();

        builder.HasMany(role => role.Users)
            .WithMany(user => user.Roles)
            .UsingEntity<UserRole>();

    }
}