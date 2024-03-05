


using ClassScheduler.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassScheduler.Domain.Configurations;
public class DepartmentEntityConfig : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasIndex(dept => dept.Id).IsUnique();
        builder.Property(dept => dept.Name).IsRequired();

        builder.HasMany(dept => dept.Students)
            .WithMany(student => student.Departments);

        builder.HasMany(dept => dept.Courses)
            .WithOne(course => course.Department)
            .HasForeignKey(course => course.DepatmentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}