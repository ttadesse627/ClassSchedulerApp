namespace ClassScheduler.Application.Contracts.ResponseDtos.RoleDtos;
public record PermissionDto
{
    public string? Name { get; set; }
    public ICollection<string> Actions { get; set; } = [];
}