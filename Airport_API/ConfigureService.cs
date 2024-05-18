
using Airport_API.Shared.Configs;
using FluentValidation.AspNetCore;
namespace Airport_API;

public static class ConfigureService
{
    public static IServiceCollection RegisterPresentationServices(this IServiceCollection services,IConfiguration configuration,string connectionString)
    {
        services.AddHealthChecks().AddSqlServer(connectionString);
        services.Configure<MySettings>(configuration.GetSection("MySettings"));
        return services;

    }
}
