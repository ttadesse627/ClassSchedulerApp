using System.Security.AccessControl;
using ClassScheduler.Application.Contracts.ResponseDtos.RoleDtos;
using ClassScheduler.Domain.Model.Entities;

namespace ClassScheduler.Application.Contracts.ResponseDtos.AuthResponseDtos;
public record AuthResponseDto
{
    public Guid Id { get; set; }
    public string? Username { get; set; }
    public string? Token { get; set; }
    public string? FullName { get; set; }
    public ICollection<PermissionDto> Permissions { get; set; } = [];
}