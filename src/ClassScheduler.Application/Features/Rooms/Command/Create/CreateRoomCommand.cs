using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Interfaces.Persistence;
using ClassScheduler.Domain.Model.Entities;
using ClassScheduler.Domain.Model.Enums;
using MediatR;

namespace ClassScheduler.Application.Features.Rooms.Command.Create;
public record CreateRoomCommand : IRequest<ServiceResponse<int>>
{
    public required string RoomNumber { get; set; }
    public string? BlockNumber { get; set; }
    public RoomType RoomType { get; set; }
}
public class CreateRoomCommandHandler(IRoomRepository roomRepository) : IRequestHandler<CreateRoomCommand, ServiceResponse<int>>
{
    private readonly IRoomRepository _roomRepository = roomRepository;
    public async Task<ServiceResponse<int>> Handle(CreateRoomCommand command, CancellationToken cancellationToken)
    {
        ServiceResponse<int> response = new();

        var roomEntity = new Room
        {
            RoomNumber = command.RoomNumber,
            BlockNumber = command.BlockNumber,
            RoomType = command.RoomType
        };

        response.Success = await _roomRepository.CreateAsync(roomEntity);
        if (response.Success)
        {
            response.Data = 1;
            response.Message = "Successfully saved a department!";
        }
        else
        {
            response.Message = "Could not save the requested room entity!";
            response.Errors.Add("Unknown error occurred!");
        }

        return response;
    }
}