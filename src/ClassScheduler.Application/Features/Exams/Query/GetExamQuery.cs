using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Contracts.ResponseDtos.ExamResponseDtos;
using ClassScheduler.Application.Interfaces.Persistence;
using MediatR;

namespace ClassScheduler.Application.Features.Exams.Query;
public record GetExamQuery(Guid Id) : IRequest<ServiceResponse<ExamResponseDto>> { }

public class GetExamQueryHandler(IExamRepository ExamRepository): IRequestHandler<GetExamQuery, ServiceResponse<ExamResponseDto>>
{
    private readonly IExamRepository _ExamRepository = ExamRepository;

    public async Task<ServiceResponse<ExamResponseDto>> Handle(GetExamQuery query, CancellationToken cancellationToken)
    {
        var responseEntity = await _ExamRepository.GetAsync(query.Id);
        var response = new ServiceResponse<ExamResponseDto>
        {
            Data = new ExamResponseDto
            {
                Id = responseEntity.Data!.Id,
                Name = responseEntity.Data.Name,
                OutOf = responseEntity.Data.OutOf,
                Remark = responseEntity.Data.Remark
            }
        };

        return response;
    }
}