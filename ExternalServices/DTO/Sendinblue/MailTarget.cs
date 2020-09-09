
using Newtonsoft.Json;

namespace ExternalServices.DTO.Sendinblue
{
    public class MailTarget
    {
        [JsonProperty("name")]
        public string Name { get; set; } = "Company Name";
        [JsonProperty("email")]
        public string Email { get; set; } = "admin@company.co.za";
    }
}
