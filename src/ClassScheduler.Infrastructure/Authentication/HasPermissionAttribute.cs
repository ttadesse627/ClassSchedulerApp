using ClassScheduler.Domain.Model.Enums;
using Microsoft.AspNetCore.Authorization;

namespace ClassScheduler.Infrastructure.Authentication;
public class HasPermissionAttribute : AuthorizeAttribute
{
    public HasPermissionAttribute(PermissionEnum permission)
    {
        Policy = permission.ToString();
    }
    public HasPermissionAttribute(string permission)
    {
        Policy = permission;
    }
}