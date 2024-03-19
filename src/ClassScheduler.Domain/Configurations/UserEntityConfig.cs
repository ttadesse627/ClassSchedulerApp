using ClassScheduler.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassScheduler.Domain.Configurations;
public class UserEntityConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {

        builder.HasOne(user => user.PersonInfo)
            .WithOne(personInfo => personInfo.User)
            .HasForeignKey<User>(user => user.PersonInfoId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(user => user.PersonInfo)
            .WithOne(personInfo => personInfo.User)
            .HasForeignKey<User>(user => user.PersonInfoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}