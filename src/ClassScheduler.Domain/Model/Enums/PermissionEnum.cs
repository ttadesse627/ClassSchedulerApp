using System.Text.Json.Serialization;

namespace ClassScheduler.Domain.Model.Enums;
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PermissionEnum
{
    CanWrite,
    CanRead,
    CanReadDetail,
    CanUpdate,
    CanDelete
}