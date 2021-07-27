using NoNonense.Application.Requests.Mail;
using System.Threading.Tasks;

namespace NoNonense.Application.Interfaces.Services
{
    public interface IMailService
    {
        Task SendAsync(MailRequest request);
    }
}