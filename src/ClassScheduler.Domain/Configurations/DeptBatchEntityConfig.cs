


using ClassScheduler.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassScheduler.Domain.Configurations;
public class DeptBatchEntityConfig : IEntityTypeConfiguration<DeptBatch>
{
    public void Configure(EntityTypeBuilder<DeptBatch> builder)
    {
        builder.HasMany(batch => batch.Students)
            .WithMany(student => student.DeptBatches);

        builder.HasMany(batch => batch.Sections)
            .WithOne(section => section.DeptBatch);

        builder.HasMany(batch => batch.Courses)
            .WithOne(course => course.DeptBatch)
            .HasForeignKey(course => course.DeptBatchId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}