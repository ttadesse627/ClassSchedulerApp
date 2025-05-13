using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Contracts.ResponseDtos.CourseResponseDtos;
using ClassScheduler.Application.Interfaces.Persistence;
using MediatR;

namespace ClassScheduler.Application.Features.Courses.Query;
public record GetByIdQuery(Guid Id) : IRequest<ServiceResponse<CourseResponseDto>> { }
public class GetByIdQueryHandler(ICourseRepository courseRepository) : IRequestHandler<GetByIdQuery, ServiceResponse<CourseResponseDto>>
{
    private readonly ICourseRepository _courseRepository = courseRepository;
    public async Task<ServiceResponse<CourseResponseDto>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        var response = new ServiceResponse<CourseResponseDto>();

        if (request.Id != Guid.Empty)
        {
            var courseEntity = await _courseRepository.GetAsync(request.Id);
            if (courseEntity is not null)
            {
                response.Data = new CourseResponseDto
                {
                    Id = courseEntity.Id,
                    Name = courseEntity.Name,
                    CourseCode = courseEntity.CourseCode,
                    CreditHours = courseEntity.CreditHours,
                    ECTS = courseEntity.ECTS,
                    DepartmentName = courseEntity.Department?.ShortName
                };
            }
            else
            {
                response.Message = "The Course with this id could not be found!";
                response.Errors.Add("Id is missing!");
            }
        }
        return response;
    }
}
