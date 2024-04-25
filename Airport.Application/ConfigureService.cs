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
            return services;
        }
    }
}
