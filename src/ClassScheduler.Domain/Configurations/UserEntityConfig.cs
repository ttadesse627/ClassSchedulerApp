using ClassScheduler.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassScheduler.Domain.Configurations;
public class UserEntityConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {

        builder.HasOne(user => user.Person)
            .WithOne(Person => Person.User)
            .HasForeignKey<User>(user => user.PersonId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}