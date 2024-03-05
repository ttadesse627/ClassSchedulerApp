using System.ComponentModel.DataAnnotations.Schema;
using ClassScheduler.Domain.Model.Entities.Base;

namespace ClassScheduler.Domain.Model.Entities;
[Table("Students")]
public class Student : BaseAuditableEntity
{
    public string? UserId { get; set; }
    public User? User { get; set; }
    public ICollection<Department>? Departments { get; set; }
    public ICollection<Course>? Courses { get; set; }
}

