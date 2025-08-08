using ClassScheduler.Application.Contracts.ResponseDtos.CampusResponseDtos;
using ClassScheduler.Application.Interfaces.Persistence;
using MediatR;

namespace ClassScheduler.Application.Features.Campuses.Query;
public record GetAllCampusesQuery : IRequest<List<CampusResponseDto>> { }

public class GetAllCampusesQueryHandler(ICampusRepository campusRepository): IRequestHandler<GetAllCampusesQuery, List<CampusResponseDto>>
{
    private readonly ICampusRepository _campusRepository = campusRepository;

    public async Task<List<CampusResponseDto>> Handle(GetAllCampusesQuery query, CancellationToken cancellationToken)
    {
        var campusEntities = await _campusRepository.GetAllAsync();
        var response = new List<CampusResponseDto>();
        foreach (var entity in campusEntities)
        {
            response.Add(new CampusResponseDto
            {
                Id = entity.Id,
                Name = entity.Name
            });
        }

        // List<CampusResponseDto> response = new List<CampusResponseDto>().AddRange(campusEntities.Select(campus => new CampusResponseDto { Id = campus.Id, Name = campus.Name }));
        return response;
    }
}