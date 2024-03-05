using ClassScheduler.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassScheduler.Domain.Configurations;
public class RoleEntityConfig : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(ur => ur.Id);

        builder.HasMany(role => role.Permissions)
            .WithMany();
    }
}