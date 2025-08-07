using ClassScheduler.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassScheduler.Domain.Configurations;
public class InstructorEntityConfig : IEntityTypeConfiguration<Instructor>
{
    public void Configure(EntityTypeBuilder<Instructor> builder)
    {
        builder.HasIndex(instructor => instructor.Id).IsUnique();

        builder.HasOne(instructor => instructor.Person)
            .WithOne(Person => Person.Instructor)
            .HasForeignKey<Instructor>(instructor => instructor.PersonId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(instructor => instructor.Courses)
            .WithMany(course => course.Instructors);
    }
}