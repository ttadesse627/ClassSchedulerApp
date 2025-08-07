using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Interfaces.Persistence;
using MediatR;

namespace ClassScheduler.Application.Features.Courses.Command.Create;
public record UpdateCourseCommand : IRequest<ServiceResponse<int>>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    public int CreditHour { get; set; }
    public int ECTS { get; set; }
    public int LabHour { get; set; }
    public int LectureHour { get; set; }
    public Guid DeptBatchId { get; set; }
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
                course.Code = request.Code;
                course.CreditHour = request.CreditHour;
                course.ECTS = request.ECTS;
                course.LabHour = request.LabHour;
                course.LectureHour = request.LectureHour;
                course.DeptBatchId = request.DeptBatchId;
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
