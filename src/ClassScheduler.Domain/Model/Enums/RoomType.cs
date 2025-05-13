using System.Text.Json.Serialization;

namespace ClassScheduler.Domain.Model.Enums;
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum RoomType
{
    Lecture = 1,
    Lab,
    Field
}