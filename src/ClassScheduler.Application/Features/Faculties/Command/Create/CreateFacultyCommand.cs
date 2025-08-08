
using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Interfaces.Persistence;
using ClassScheduler.Domain.Model.Entities;
using MediatR;

namespace ClassScheduler.Application.Features.Faculties.Command.Create;
public record CreateFacultyCommand: IRequest<ServiceResponse<int>>{
    public required string Name { get; set; }
    public Guid CampusId { get; set; }
}
public class CreateFacultyCommandHandler(IFacultyRepository facultyRepository): IRequestHandler<CreateFacultyCommand, ServiceResponse<int>>
{
    private readonly IFacultyRepository _facultyRepository = facultyRepository;

    public async Task<ServiceResponse<int>> Handle(CreateFacultyCommand command, CancellationToken cancellationToken)
    {
        Faculty faculty = new Faculty {
            Name = command.Name,
            CampusId = command.CampusId
        };
        var response = await _facultyRepository.Create(faculty, cancellationToken);
        return response;
    }
}