using ClassScheduler.Application.Interfaces.Persistence;
using MediatR;
using ClassScheduler.Application.Contracts.ResponseDtos.FacultyResponseDtos;

namespace ClassScheduler.Application.Features.Faculties.Query;
public record GetAllFacultiesQuery : IRequest<List<FacultiesResponseDto>> { }

public class GetAllFacultiesQueryHandler(IFacultyRepository facultyRepository): IRequestHandler<GetAllFacultiesQuery, List<FacultiesResponseDto>>
{
    private readonly IFacultyRepository _facultyRepository = facultyRepository;

    public async Task<List<FacultiesResponseDto>> Handle(GetAllFacultiesQuery query, CancellationToken cancellationToken)
    {
        var facultyEntities = await _facultyRepository.GetAllAsync();
        var response = new List<FacultiesResponseDto>();
        foreach (var entity in facultyEntities)
        {
            response.Add(new FacultiesResponseDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Campus = entity.Campus?.Name
            });
        }
        return response;
    }
}