using Airport.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Airport.Application.Contracts;
using Airport.Infrastructure.Persistance.Repositories;

namespace Airport.Infrastructure;

public static class ConfigureService
{
    public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, string connectionString)
    { 
        services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(connectionString));

        services.AddScoped<IFlightService, FlightService>();

        return services;
    }
}

