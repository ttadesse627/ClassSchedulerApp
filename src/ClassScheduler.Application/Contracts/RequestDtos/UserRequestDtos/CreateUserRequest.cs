
using ClassScheduler.Application.Contracts.RequestDtos.Common;

namespace ClassScheduler.Application.Contracts.RequestDtos.UserRequestDtos;
public record CreateUserRequest
{
    public string Username { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public PersonInfoRequest? PersonInfo { get; set; }
    public ICollection<Guid> RoleIds { get; set; } = [];
}