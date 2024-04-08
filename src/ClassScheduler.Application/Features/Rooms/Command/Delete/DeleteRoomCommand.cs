using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Interfaces.Persistence;
using ErrorOr;
using MediatR;

namespace ClassScheduler.Application.Features.Rooms.Command.Delete;
public record DeleteRoomCommand(Guid Id) : IRequest<ServiceResponse<int>> { }

public class DeleteRoomCommandHandler(IRoomRepository roomRepository) : IRequestHandler<DeleteRoomCommand, ServiceResponse<int>>
{
    private readonly IRoomRepository _roomRepository = roomRepository;
    public async Task<ServiceResponse<int>> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
    {
        var response = new ServiceResponse<int>();

        var roomEntity = await _roomRepository.GetAsync(request.Id);
        if (roomEntity is null)
        {
            response.Message = $"Could not find a room with an id {request.Id}";
        }
        else
        {
            response.Success = await _roomRepository.DeleteAsync(roomEntity);
            if (response.Success)
            {
                response.Data = 1;
                response.Message = "Successfully deleted a room!";
            }

            else
            {
                response.Message = "Successfully deleted a room!";
                response.Errors.Add("Could not delete room entity");
            }
        }

        return response;
    }
}