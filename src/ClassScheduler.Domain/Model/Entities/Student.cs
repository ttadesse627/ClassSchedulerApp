using System.ComponentModel.DataAnnotations.Schema;
using ClassScheduler.Domain.Model.Entities.Base;

namespace ClassScheduler.Domain.Model.Entities;
[Table("Students")]
public class Student : BaseAuditableEntity
{
    public Guid? PersonId { get; set; }
    public Person? Person { get; set; }
    public ICollection<DeptBatch>? DeptBatches { get; set; } = [];
    public ICollection<Section>? Sections { get; set; } = [];
    public ICollection<Course>? Courses { get; set; } = [];
}

