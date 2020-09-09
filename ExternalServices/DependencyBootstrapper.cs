
using ExternalServices.ConfigProviders;
using ExternalServices.Contract;
using ExternalServices.Core.RealmDigital;
using ExternalServices.Core.SmtpProvider;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExternalServices
{
    public static class Dependencies
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration _)
        {
            services.AddHttpClient<IEmployeeApiProvider, EmployeeApi>();
            services.AddHttpClient<ISmtpMailProvider, Sendinblue>();

            services.AddSingleton<IEmployeeApiConfigurationProvider, EmployeeApiConfigurationProviderSource>();
            services.AddSingleton<ISmtpMailProviderConfigurationProvider, SmtpMailProviderConfigurationProviderSource>();
        }
    }
}
