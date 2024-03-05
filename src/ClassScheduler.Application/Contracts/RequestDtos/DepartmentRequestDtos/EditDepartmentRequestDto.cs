

namespace ClassScheduler.Application.Contracts.RequestDtos.DepartmentRequestDtos;
public record EditDepartmentRequestDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string ShortName { get; set; } = null!;
    public int NumberOfSemisters { get; set; }
    public int CurrentSemister { get; set; }
}