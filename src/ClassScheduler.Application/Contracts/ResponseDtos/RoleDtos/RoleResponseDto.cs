namespace ClassScheduler.Application.Contracts.ResponseDtos.RoleDtos;
public record RoleResponseDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public ICollection<PermissionDto> Permissions { get; set; } = [];
}