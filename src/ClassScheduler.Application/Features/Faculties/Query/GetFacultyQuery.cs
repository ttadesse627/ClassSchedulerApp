using ClassScheduler.Application.Contracts.ResponseDtos.CampusResponseDtos;
using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Contracts.ResponseDtos.FacultyResponseDtos;
using ClassScheduler.Application.Interfaces.Persistence;
using MediatR;

namespace ClassScheduler.Application.Features.Faculties.Query;
public record GetFacultyQuery(Guid Id) : IRequest<ServiceResponse<FacultyResponseDto>> { }

public class GetFacultyQueryHandler(IFacultyRepository facultyRepository): IRequestHandler<GetFacultyQuery, ServiceResponse<FacultyResponseDto>>
{
    private readonly IFacultyRepository _facultyRepository = facultyRepository;

    public async Task<ServiceResponse<FacultyResponseDto>> Handle(GetFacultyQuery query, CancellationToken cancellationToken)
    {
        var responseEntity = await _facultyRepository.GetAsync(query.Id);
        var response = new ServiceResponse<FacultyResponseDto>
        {
            Data = new FacultyResponseDto
            {
                Id = responseEntity.Data!.Id,
                Name = responseEntity.Data.Name,
                Campus = new CampusResponseDto
                {
                    Id = responseEntity.Data.Id,
                    Name = responseEntity.Data.Campus?.Name
                }
            }
        };

        return response;
    }
}