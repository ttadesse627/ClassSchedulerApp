using ClassScheduler.Infrastructure.Context;
using ClassScheduler.Infrastructure.Persistence;
using ClassScheduler.Application.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace ClassScheduler.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfigurationManager configurationManager)
    {
        services.AddDbContext<ClassSchedulerDbContext>(options =>
            options.UseMySql(configurationManager.GetConnectionString("ClassSchedulerConnectionStrings"), ServerVersion.AutoDetect(configurationManager.GetConnectionString("ClassSchedulerConnectionStrings"))));
        services.AddTransient(typeof(IStudentRepository), typeof(StudentRepository));
        services.AddTransient(typeof(IDepartmentRepository), typeof(DepartmentRepository));
        services.AddTransient(typeof(IUserRepository), typeof(UserRepository));
        services.AddTransient(typeof(IRoleRepository), typeof(RoleRepository));
        return services;
    }
}