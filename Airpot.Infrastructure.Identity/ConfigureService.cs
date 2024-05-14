using Airport.Infrastructure.Identity.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection.Metadata.Ecma335;

namespace Airport.Infrastructure.Identity;

public static class ConfigureService
{
    public static IServiceCollection RegisterIdentityInfrastructureServices(this IServiceCollection services,string connectionString)
    {
        services.AddDbContext<ApplicationIdentityContext>(options =>
               options.UseSqlServer(
        connectionString,
                   b => b.MigrationsAssembly(typeof(ApplicationIdentityContext).Assembly.FullName)));
        return services;
    }
    
}

