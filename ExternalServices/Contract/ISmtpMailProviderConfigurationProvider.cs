
namespace ExternalServices.Contract
{
    public interface ISmtpMailProviderConfigurationProvider
    {
        string HostUrl { get; }
        string ApiKey { get; }
    }
}
