using ClassScheduler.Application.Contracts.RequestDtos.RoomRequestDtos;
using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Interfaces.Persistence;
using ClassScheduler.Domain.Model.Entities;
using MapsterMapper;
using MediatR;

namespace ClassScheduler.Application.Features.Rooms.Command.Update;
public record EditRoomCommand(EditRoomRequestDto RoomRequestDto) : IRequest<ServiceResponse<string>> { }
public class EditRoomCommandHandler(IRoomRepository roomRepository, IMapper mapper) : IRequestHandler<EditRoomCommand, ServiceResponse<string>>
{
    private readonly IRoomRepository _roomRepository = roomRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<ServiceResponse<string>> Handle(EditRoomCommand command, CancellationToken cancellationToken)
    {
        var response = new ServiceResponse<string>();
        if (command.RoomRequestDto is null)
        {
            response.Success = false;
            response.Data = "Invalid Operation";
            response.Errors!.Add("The room edit payload should not be null");
            response.Message = "There should be a room data to edit";
        }
        else if (command.RoomRequestDto.Id == Guid.Empty)
        {
            response.Success = false;
            response.Data = "Invalid Operation";
            response.Errors!.Add("The room to be edited should have a valid Id");
            response.Message = "The room id should not be empty to edit";
        }
        else
        {
            var roomEntity = _mapper.Map<Room>(command.RoomRequestDto);
            response.Success = await _roomRepository.UpdateAsync(roomEntity);
            if (response.Success)
            {
                response.Success = true;
                response.Data = "Operation Succeed";
                response.Message = "You've successfully edited";
            }
            // }
        }
        return response;
    }
}
