using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace ClassScheduler.Infrastructure.Authentication;
public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
    // private readonly IServiceScopeFactory _serviceScope = serviceScope;
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {
        await Task.CompletedTask;
        string? userid = context.User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub)?.Value;
        if (!Guid.TryParse(userid, out Guid parsedUserId))
        {
            return;
        }

        // using IServiceScope serviceScope = _serviceScope.CreateScope();
        // // IPermissionRepository permissionRepository = serviceScope.ServiceProvider.GetRequiredService<IPermissionRepository>();
        // HashSet<string> permissions = await permissionRepository.GetPermissionAsync(parsedUserId.ToString());

        // if (permissions.Contains(requirement.Permission))
        // {
        //     context.Succeed(requirement);
        // }
    }
}
