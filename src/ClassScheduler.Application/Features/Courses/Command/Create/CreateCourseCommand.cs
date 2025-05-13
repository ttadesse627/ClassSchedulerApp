using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Interfaces.Persistence;
using ClassScheduler.Domain.Model.Entities;
using MediatR;

namespace ClassScheduler.Application.Features.Courses.Command.Create;
public record CreateCourseCommand : IRequest<ServiceResponse<int>>
{
    public ICollection<CreateCourseRequest> Courses { get; set; } = [];
    public Guid DepartmentId { get; set; }
}

public class CreateCourseCommandHandler(ICourseRepository courseRepository) : IRequestHandler<CreateCourseCommand, ServiceResponse<int>>
{
    private readonly ICourseRepository _courseRepository = courseRepository;
    public async Task<ServiceResponse<int>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        var response = new ServiceResponse<int>();
        IList<Course> courses = [];
        Console.WriteLine(request);
        if (request.Courses.Count > 0)
        {
            foreach (var course in request.Courses)
            {
                var courseEntity = new Course
                {
                    Name = course.Name,
                    CourseCode = course.CourseCode,
                    CreditHours = course.CreditHours,
                    ECTS = course.ECTS,
                    DepatmentId = request.DepartmentId
                };
                courses.Add(courseEntity);
            }
            response.Success = await _courseRepository.CreateAsync(courses);
            if (response.Success)
            {
                response.Message = "Successfully created course/s";
                response.Data = 1;
            }
            else
            {
                response.Message = "Couldn't created course/s";
                response.Errors.Add("Couldn't created course/s");
            }
        }
        else
        {
            response.Message = "Courses should not be empty.";
            response.Errors.Add("Courses field required");
        }
        return response;
    }
}
