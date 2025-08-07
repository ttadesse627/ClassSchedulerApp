
using ClassScheduler.Application.Contracts.RequestDtos.Common;

namespace ClassScheduler.Application.Contracts.RequestDtos.UserRequestDtos;
public record CreateUserRequest
{
    public required string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Username { get; set; }
    public string Password { get; set; } = string.Empty;
    public PersonRequest? Person { get; set; }
    public ICollection<Guid> RoleIds { get; set; } = [];
}