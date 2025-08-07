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

        builder.HasMany(student => student.DeptBatches)
            .WithMany(batch => batch.Students);

        builder.HasMany(student => student.Sections)
            .WithMany(batch => batch.Students);

        builder.HasOne(student => student.Person)
            .WithOne(Person => Person.Student)
            .HasForeignKey<Student>(student => student.PersonId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}