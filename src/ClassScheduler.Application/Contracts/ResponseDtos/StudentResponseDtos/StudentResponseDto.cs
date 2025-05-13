using ClassScheduler.Application.Contracts.ResponseDtos.DepartmentResponseDtos;
using ClassScheduler.Application.Contracts.ResponseDtos.PersonInfoDtos;


namespace ClassScheduler.Application.Contracts.ResponseDtos.StudentResponseDts;
public record StudentResponseDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string MiddleName { get; set; } = null!;
    public string? LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public string? CreatedUser { get; set; }
    public string? ModifiedUser { get; set; }
    public DepartmentResponseDto Department { get; set; } = null!;
}