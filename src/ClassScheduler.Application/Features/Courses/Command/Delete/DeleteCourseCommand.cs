using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Interfaces.Persistence;
using ClassScheduler.Domain.Model.Entities;
using MediatR;

namespace ClassScheduler.Application.Features.Courses.Delete.Create;
public record DeleteCourseCommand(Guid Id) : IRequest<ServiceResponse<int>>{}

public class CreateCourseCommandHandler(ICourseRepository courseRepository) : IRequestHandler<DeleteCourseCommand, ServiceResponse<int>>
{
    private readonly ICourseRepository _courseRepository = courseRepository;
    public async Task<ServiceResponse<int>> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
    {
        var response = new ServiceResponse<int>();

        if (request.Id != Guid.Empty)
        {
            Course? courseEntity = await _courseRepository.GetAsync(request.Id);
            if (courseEntity is null)
            {
                response.Message = "There is no course found with provided id";
                response.Errors.Add("Null value error");
            }
            else
            {
                response.Success = await _courseRepository.DeleteAsync(courseEntity);
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
