


using System.Reflection;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClassScheduler.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfigurationManager configurationManager)
    {
        //Configure Mediator DI
        services.AddMapster();
        services.AddMediatR(typeof(DependencyInjection).Assembly);

        //Configure the Mapper DI
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());
        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();


        return services;
    }
}