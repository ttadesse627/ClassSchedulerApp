namespace ClassScheduler.Domain.Model.Entities;
public class Class
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid CourseId { get; set; }
    public required Course Course { get; set; }
    public Guid RoomId { get; set; }
    public required Room Room { get; set; }
    public Guid SectionId { get; set; }
    public required Section Section { get; set; }
    public Guid TimeSlotId { get; set; }
    public required TimeSlot TimeSlot { get; set; }
    public Guid InstructorId { get; set; }
    public required Instructor Instructor { get; set; }
}
