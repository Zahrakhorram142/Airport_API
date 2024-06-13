using Airport.Application.Profiles;
using Airport.Domain.Contracts;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Airport.Application
{
    public static class ConfigureService
    {
        public static IServiceCollection RegisterApplicationServices( this IServiceCollection services)
        { 
            services.AddAutoMapper(typeof(FlightProfile));
            services.AddFluentValidationAutoValidation();

            var assembly= typeof(ConfigureService).Assembly;

            services.AddMediatR(configuration =>
                configuration.RegisterServicesFromAssembly(assembly));

            return services;
        }
    }
}
