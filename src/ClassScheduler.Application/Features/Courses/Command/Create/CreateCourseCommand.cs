using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Interfaces.Persistence;
using ClassScheduler.Domain.Model.Entities;
using MediatR;

namespace ClassScheduler.Application.Features.Courses.Command.Create;
public record CreateCourseCommand : IRequest<ServiceResponse<int>>
{
    public required string Name { get; set; }
    public required string CourseCode { get; set; }
    public int CreditHours { get; set; }
    public int ECTS { get; set; }
    public Guid DepartmentId { get; set; }
}

public class CreateCourseCommandHandler(ICourseRepository courseRepository) : IRequestHandler<CreateCourseCommand, ServiceResponse<int>>
{
    private readonly ICourseRepository _courseRepository = courseRepository;
    public async Task<ServiceResponse<int>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        var response = new ServiceResponse<int>();
        if (!string.IsNullOrEmpty(request.Name) && !string.IsNullOrEmpty(request.CourseCode))
        {
            var courseEntity = new Course
            {
                Name = request.Name,
                CourseCode = request.CourseCode,
                CreditHours = request.CreditHours,
                ECTS = request.ECTS,
                DepatmentId = request.DepartmentId
            };
            var resp = await _courseRepository.CreateAsync(courseEntity);
            if (resp)
            {
                response.Success = resp;
                response.Message = "Successfully Created";
                response.Data = 1;
            }
            else
            {
                response.Message = "Couldn't create a course with a given request!";
                response.Errors.Add("Unknown Error");
            }
        }
        else
        {
            response.Message = "The course should have a name or code.";
            response.Errors.Add("Null value error");
        }
        return response;
    }
}
