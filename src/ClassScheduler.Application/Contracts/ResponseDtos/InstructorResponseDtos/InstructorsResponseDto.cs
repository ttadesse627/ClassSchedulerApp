namespace ClassScheduler.Application.Contracts.ResponseDtos.InstructorResponseDts;
public record InstructorsResponseDto
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    public int NumberOfAssignedCourses { get; set; }
}