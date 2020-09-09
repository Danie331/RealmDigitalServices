
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ExternalServices.DTO.Sendinblue
{
    public class MailObject
    {
        [JsonProperty("sender")]
        public MailTarget Sender { get; set; }
        [JsonProperty("to")]
        public IEnumerable<MailTarget> To { get; set; }
        [JsonProperty("subject")]
        public string Subject { get; set; }
        [JsonProperty("htmlContent")]
        public string HtmlContent { get; set; }
    }
}
