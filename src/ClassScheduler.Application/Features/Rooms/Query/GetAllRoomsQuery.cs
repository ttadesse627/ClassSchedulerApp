using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Contracts.ResponseDtos.RoomResponseDtos;
using ClassScheduler.Application.Interfaces.Persistence;
using MapsterMapper;
using MediatR;

namespace ClassScheduler.Application.Features.Departments.Query;
public record GetAllRoomsQuery : IRequest<ServiceResponse<List<RoomResponseDto>>> { }
public class GetAllRoomsQueryHandler(IRoomRepository roomRepository, IMapper mapper) : IRequestHandler<GetAllRoomsQuery, ServiceResponse<List<RoomResponseDto>>>
{
    private readonly IRoomRepository _roomRepository = roomRepository;
    private readonly IMapper _mapper = mapper;
    public async Task<ServiceResponse<List<RoomResponseDto>>> Handle(GetAllRoomsQuery request, CancellationToken cancellationToken)
    {
        var response = new ServiceResponse<List<RoomResponseDto>>();
        var rooms = await _roomRepository.GetAllAsync();
        if (rooms.Count > 0)
        {
            var roomDtos = _mapper.Map<List<RoomResponseDto>>(rooms);
            response.Data = roomDtos;
        }
        return response;
    }
}