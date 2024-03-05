

namespace ClassScheduler.Domain.Model.Entities;
public class UserRole
{
    public Guid Id { get; set; }
    public string UserId { get; set; } = string.Empty;
    public string RoleId { get; set; } = string.Empty;
}