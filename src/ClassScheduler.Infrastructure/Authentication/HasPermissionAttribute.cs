using ClassScheduler.Domain.Model.Enums;
using Microsoft.AspNetCore.Authorization;

namespace ClassScheduler.Infrastructure.Authentication;
public class HasPermissionAttribute(PermissionEnum permission) : AuthorizeAttribute(permission.ToString()) { }