namespace ClassScheduler.Domain.Model.Entities;
public class Faculty
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public Guid CampusId { get; set; }
    public Campus? Campus { get; set; }
}