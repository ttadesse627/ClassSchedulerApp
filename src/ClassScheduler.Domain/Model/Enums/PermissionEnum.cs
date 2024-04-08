

using System.Text.Json.Serialization;

namespace ClassScheduler.Domain.Model.Enums;
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PermissionEnum
{
    WriteMember,
    ReadMember,
    ReadDetailMember,
    UpdateMember,
    DeleteMember
}