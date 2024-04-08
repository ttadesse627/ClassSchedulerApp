using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Contracts.ResponseDtos.RoomResponseDtos;
using ClassScheduler.Application.Interfaces.Persistence;
using MediatR;

namespace ClassScheduler.Application.Features.Rooms.Query;
public record GetByIdQuery(Guid Id) : IRequest<ServiceResponse<RoomResponseDto>> { }
public class GetByIdQueryHandler(IRoomRepository roomRepository) : IRequestHandler<GetByIdQuery, ServiceResponse<RoomResponseDto>>
{
    private readonly IRoomRepository _roomRepository = roomRepository;
    public async Task<ServiceResponse<RoomResponseDto>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        var response = new ServiceResponse<RoomResponseDto>();

        if (request.Id != Guid.Empty)
        {
            var roomEntity = await _roomRepository.GetAsync(request.Id);
            if (roomEntity is not null)
            {
                response.Data = new RoomResponseDto
                {
                    Id = roomEntity.Id,
                    RoomNumber = roomEntity.RoomNumber,
                    BlockNumber = roomEntity.BlockNumber,
                    RoomType = roomEntity.RoomType,
                    IsAvailable = roomEntity.IsAvailable
                };
            }
            else
            {
                response.Message = "The Room with this id could not be found!";
                response.Errors.Add("Id is missing!");
            }
        }
        return response;
    }
}
