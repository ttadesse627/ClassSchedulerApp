using System.Text.Json.Serialization;

namespace ClassScheduler.Domain.Model.Enums;
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum WeekDay
{
    Sunday,
    Monday,
    Tuesday,
    Wednesday,
    Thrusday,
    Friday,
    Saturday
}
