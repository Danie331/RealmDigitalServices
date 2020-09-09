using AutoMapper;
using DAL;
using DAL.Contract;
using DAL.Core;
using ExternalServices.ConfigProviders;
using ExternalServices.Contract;
using ExternalServices.Core.RealmDigital;
using ExternalServices.Core.SmtpProvider;
using InternalServices.Contract;
using InternalServices.Core;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Tests
{
    public class DependencyConfiguration
    {
        public IServiceProvider CreateServiceProvider()
        {
            var serviceProviderCollection =
                new ServiceCollection()
                .AddSingleton<IEmployeeApiConfigurationProvider, EmployeeApiConfigurationProviderSource>()
                .AddSingleton<ISmtpMailProviderConfigurationProvider, SmtpMailProviderConfigurationProviderSource>()
                .AddHttpClient<IEmployeeApiProvider, EmployeeApi>()
                .Services
                .AddHttpClient<ISmtpMailProvider, Sendinblue>()
                .Services
                .AddScoped<IEmployeeStore, EmployeeStore>()
                .AddScoped<IEmployeeBirthdayMailerService, EmployeeBirthdayMailerService>()
                .AddScoped<AssessmentContext, AssessmentContext>();

            serviceProviderCollection.AddAutoMapper(GetType().Assembly, typeof(DAL.Automapper.AutoMapperProfile).Assembly,
                                                                        typeof(ExternalServices.Automapper.AutoMapperProfile).Assembly);

            return serviceProviderCollection.BuildServiceProvider();
        }
    }
}
