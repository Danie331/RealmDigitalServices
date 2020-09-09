
using DomainTypes;
using ExternalServices.Contract;
using ExternalServices.DTO.Sendinblue;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ExternalServices.Core.SmtpProvider
{
    public class Sendinblue : ISmtpMailProvider
    {
        private readonly ISmtpMailProviderConfigurationProvider _configProvider;
        private readonly HttpClient _httpClient;

        public Sendinblue(ISmtpMailProviderConfigurationProvider configProvider,
                          HttpClient httpClient)
        {
            _configProvider = configProvider;
            _httpClient = httpClient;

            _httpClient.BaseAddress = new Uri(_configProvider.HostUrl);
        }

        public async Task SendEmailAsync(MailMessage msg)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Add("api-key", _configProvider.ApiKey);
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var mailObject = new MailObject
                {
                    Sender = new MailTarget { },
                    To = new[] { new MailTarget { Name = msg.To, Email = msg.EmailAddress } },
                    Subject = msg.Subject,
                    HtmlContent = msg.Body
                };
                var mailObjectString = JsonConvert.SerializeObject(mailObject);
                await _httpClient.PostAsync("smtp/email", new StringContent(mailObjectString, Encoding.UTF8, "application/json"));
            }
            catch (Exception ex)
            {
                // Log using default logging provider
                throw;
            }
        }
    }
}
