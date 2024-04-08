using ClassScheduler.Application.Contracts.ResponseDtos.CourseResponseDtos;

namespace ClassScheduler.Application.Contracts.ResponseDtos.InstructorResponseDts;
public record InstructorResponseDto
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
    public ICollection<CourseResponseDto> Courses { get; set; } = [];
}