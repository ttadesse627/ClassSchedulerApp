using ClassScheduler.Domain.Model.Enums;

namespace ClassScheduler.Application.Contracts.RequestDtos.RoomRequestDtos;
public record EditRoomRequestDto
{
    public Guid Id { get; set; }
    public required string Code { get; set; }
    public string? BlockNumber { get; set; }
    public RoomType RoomType { get; set; }
}