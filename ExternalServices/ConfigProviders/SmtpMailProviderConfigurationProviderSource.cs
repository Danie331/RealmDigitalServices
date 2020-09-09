
using ExternalServices.Contract;

namespace ExternalServices.ConfigProviders
{
    public class SmtpMailProviderConfigurationProviderSource : ISmtpMailProviderConfigurationProvider
    {
        public string HostUrl => "https://api.sendinblue.com/v3/";

        public string ApiKey => "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";
    }
}
