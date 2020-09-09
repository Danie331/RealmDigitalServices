
using InternalServices.Contract;
using InternalServices.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InternalServices
{
    public static class Dependencies
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration _)
        {
            services.AddScoped<IEmployeeBirthdayMailerService, EmployeeBirthdayMailerService>();

            ExternalServices.Dependencies.RegisterServices(services, _);
        }
    }
}
