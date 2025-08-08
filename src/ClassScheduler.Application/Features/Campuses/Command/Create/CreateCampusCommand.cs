
using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Interfaces.Persistence;
using ClassScheduler.Domain.Model.Entities;
using MediatR;

namespace ClassScheduler.Application.Features.Campuses.Command.Create;
public record CreateCampusCommand: IRequest<ServiceResponse<int>>{
    public required string Name { get; set; }
}
public class CreateCampusCommandHandler(ICampusRepository campusRepository): IRequestHandler<CreateCampusCommand, ServiceResponse<int>>
{
    private readonly ICampusRepository _campusRepository = campusRepository;

    public async Task<ServiceResponse<int>> Handle(CreateCampusCommand command, CancellationToken cancellationToken)
    {
        Campus campus = new Campus { Name = command.Name };
        var response = await _campusRepository.Create(campus, cancellationToken);
        return response;
    }
}