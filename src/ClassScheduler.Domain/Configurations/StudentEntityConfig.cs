


using ClassScheduler.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassScheduler.Domain.Configurations;
public class StudentEntityConfig : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {

        builder.HasMany(student => student.Courses)
            .WithMany(course => course.Students);

        builder.HasMany(student => student.Departments)
            .WithMany(department => department.Students);

        builder.HasOne(student => student.User)
            .WithOne(user => user.Student)
            .HasForeignKey<Student>(student => student.UserId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}