using ClassScheduler.Application.Contracts.ResponseDtos.CourseResponseDtos;
using ClassScheduler.Application.Interfaces.Persistence;
using MediatR;

namespace ClassScheduler.Application.Features.Courses.Query;
public record GetAllCoursesQuery : IRequest<List<CourseResponseDto>> { }
public class GetAllCoursesQueryHandler(ICourseRepository courseRepository) : IRequestHandler<GetAllCoursesQuery, List<CourseResponseDto>>
{
    private readonly ICourseRepository _courseRepository = courseRepository;
    public async Task<List<CourseResponseDto>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
    {
        var response = new List<CourseResponseDto>();
        var courseEntities = await _courseRepository.GetAllAsync();
        if (courseEntities.Count > 0)
        {
            foreach (var courseEntity in courseEntities)
            {
                response.Add(
                    new CourseResponseDto
                    {
                        Id = courseEntity.Id,
                        Name = courseEntity.Name,
                        Code = courseEntity.Code,
                        CreditHour = courseEntity.CreditHour,
                        ECTS = courseEntity.ECTS,
                        BatchName = courseEntity.DeptBatch?.Name
                    }
                );
            }
        }
        return response;
    }
}
