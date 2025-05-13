using ClassScheduler.Domain.Model.Enums;

namespace ClassScheduler.Application.Contracts.ResponseDtos.RoomResponseDtos;
public record RoomResponseDto
{
    public Guid Id { get; set; }
    public required string RoomNumber { get; set; }
    public string? BlockNumber { get; set; }
    public RoomType RoomType { get; set; }
    public bool IsAvailable { get; set; }
}