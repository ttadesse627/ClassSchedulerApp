using ClassScheduler.Infrastructure.Context;
using ClassScheduler.Infrastructure.Persistence;
using ClassScheduler.Application.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ClassScheduler.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ClassScheduler.Domain.Model.Entities;


namespace ClassScheduler.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfigurationManager configurationManager)
    {
        services.AddDbContext<ClassSchedulerDbContext>(options =>
            options.UseMySql(configurationManager.GetConnectionString("ClassSchedulerConnectionStrings"), ServerVersion.AutoDetect(configurationManager.GetConnectionString("ClassSchedulerConnectionStrings"))));

        services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();
        services.AddSingleton<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();
        services.AddTransient(typeof(IStudentRepository), typeof(StudentRepository));
        services.AddTransient(typeof(IInstructorRepository), typeof(InstructorRepository));
        services.AddTransient(typeof(IDepartmentRepository), typeof(DepartmentRepository));
        services.AddTransient(typeof(ICourseRepository), typeof(CourseRepository));
        services.AddTransient(typeof(IRoomRepository), typeof(RoomRepository));
        services.AddTransient(typeof(IUserRepository), typeof(UserRepository));
        services.AddTransient(typeof(IRoleRepository), typeof(RoleRepository));
        services.AddTransient(typeof(IPermissionRepository), typeof(PermissionRepository));

        services.AddIdentity<User, IdentityRole>()
        .AddEntityFrameworkStores<ClassSchedulerDbContext>();
        services.AddScoped<UserManager<User>>();
        return services;
    }
}