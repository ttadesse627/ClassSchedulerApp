using ClassScheduler.Application.Interfaces.Persistence;
using MediatR;
using ClassScheduler.Application.Contracts.ResponseDtos.ExamResponseDtos;

namespace ClassScheduler.Application.Features.Exams.Query;
public record GetAllExamsQuery : IRequest<List<ExamResponseDto>> { }

public class GetAllExamsQueryHandler(IExamRepository examRepository): IRequestHandler<GetAllExamsQuery, List<ExamResponseDto>>
{
    private readonly IExamRepository _examRepository = examRepository;

    public async Task<List<ExamResponseDto>> Handle(GetAllExamsQuery query, CancellationToken cancellationToken)
    {
        var ExamEntities = await _examRepository.GetAllAsync();
        var response = new List<ExamResponseDto>();
        foreach (var entity in ExamEntities)
        {
            response.Add(new ExamResponseDto
            {
                Id = entity.Id,
                Name = entity.Name,
                OutOf = entity.OutOf
            });
        }
        return response;
    }
}