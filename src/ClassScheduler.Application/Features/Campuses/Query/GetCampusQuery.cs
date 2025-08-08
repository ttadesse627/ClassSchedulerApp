using ClassScheduler.Application.Contracts.ResponseDtos.CampusResponseDtos;
using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Interfaces.Persistence;
using MediatR;

namespace ClassScheduler.Application.Features.Campuses.Query;
public record GetCampusQuery(Guid Id) : IRequest<ServiceResponse<CampusResponseDto>> { }

public class GetCampusQueryHandler(ICampusRepository campusRepository): IRequestHandler<GetCampusQuery, ServiceResponse<CampusResponseDto>>
{
    private readonly ICampusRepository _campusRepository = campusRepository;

    public async Task<ServiceResponse<CampusResponseDto>> Handle(GetCampusQuery query, CancellationToken cancellationToken)
    {
        var responseEntity = await _campusRepository.GetAsync(query.Id);
        var response = new ServiceResponse<CampusResponseDto>
        {
            Data = new CampusResponseDto
            {
                Id = responseEntity.Data!.Id,
                Name = responseEntity.Data.Name
            }
        };

        return response;
    }
}