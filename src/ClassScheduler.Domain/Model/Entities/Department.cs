

using ClassScheduler.Domain.Model.Entities.Base;

namespace ClassScheduler.Domain.Model.Entities;
public class Department : BaseAuditableEntity
{
    public string Name { get; set; } = null!;
    public string ShortName { get; set; } = null!;
    public int NumberOfSemisters { get; set; }
    public int CurrentSemister { get; set; }
    public ICollection<Course> Courses { get; set; } = [];
    public ICollection<Room> Rooms { get; set; } = [];
    public ICollection<Student> Students { get; set; } = [];
}