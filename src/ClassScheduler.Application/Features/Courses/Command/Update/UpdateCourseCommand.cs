using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Interfaces.Persistence;
using MediatR;

namespace ClassScheduler.Application.Features.Courses.Command.Create;
public record UpdateCourseCommand : IRequest<ServiceResponse<int>>
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string CourseCode { get; set; }
    public int CreditHours { get; set; }
    public int ECTS { get; set; }
    public Guid DepartmentId { get; set; }
}

public class UpdateCourseCommandHandler(ICourseRepository courseRepository) : IRequestHandler<UpdateCourseCommand, ServiceResponse<int>>
{
    private readonly ICourseRepository _courseRepository = courseRepository;
    public async Task<ServiceResponse<int>> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
    {
        var response = new ServiceResponse<int>();
        if (request.Id != Guid.Empty)
        {
            var course = await _courseRepository.GetAsync(request.Id);

            if (course is not null)
            {
                course.Name = request.Name;
                course.CourseCode = request.CourseCode;
                course.CreditHours = request.CreditHours;
                course.ECTS = request.ECTS;
                course.DepatmentId = request.DepartmentId;
            }

            var resp = await _courseRepository.SaveChangesAsync(cancellationToken);
            if (resp > 0)
            {
                response.Data = 1;
                response.Message = "Successfully updated the course!";
                response.Success = true;
            }
        }

        return response;
    }
}
