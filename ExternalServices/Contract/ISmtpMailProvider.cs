
using DomainTypes;
using System.Threading.Tasks;

namespace ExternalServices.Contract
{
    public interface ISmtpMailProvider
    {
        Task SendEmailAsync(MailMessage email);
    }
}
