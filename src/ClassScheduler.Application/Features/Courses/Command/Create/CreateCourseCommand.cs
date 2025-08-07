using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Interfaces.Persistence;
using ClassScheduler.Domain.Model.Entities;
using MediatR;

namespace ClassScheduler.Application.Features.Courses.Command.Create;
public record CreateCourseCommand : IRequest<ServiceResponse<int>>
{
    public ICollection<CreateCourseRequest> Courses { get; set; } = [];
    public Guid DeptBatchId { get; set; }
}

public class CreateCourseCommandHandler(ICourseRepository courseRepository) : IRequestHandler<CreateCourseCommand, ServiceResponse<int>>
{
    private readonly ICourseRepository _courseRepository = courseRepository;
    public async Task<ServiceResponse<int>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        var response = new ServiceResponse<int>();
        List<Course> courses = [];
        if (request.Courses.Count > 0)
        {
            foreach (var course in request.Courses)
            {
                var courseEntity = new Course 
                {
                    Name = course.Name,
                    Code = course.Code,
                    CreditHour = course.CreditHour,
                    ECTS = course.ECTS,
                    LabHour = course.LabHour,
                    LectureHour = course.LectureHour,
                    DeptBatchId = request.DeptBatchId
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
