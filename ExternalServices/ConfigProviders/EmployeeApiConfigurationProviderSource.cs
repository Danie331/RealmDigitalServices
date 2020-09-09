
using ExternalServices.Contract;

namespace ExternalServices.ConfigProviders
{
    public class EmployeeApiConfigurationProviderSource : IEmployeeApiConfigurationProvider
    {
        string IEmployeeApiConfigurationProvider.HostAddress => "https://interview-assessment-1.realmdigital.co.za";
    }
}
