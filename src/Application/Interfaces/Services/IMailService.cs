using NowWhat.Application.Requests.Mail;
using System.Threading.Tasks;

namespace NowWhat.Application.Interfaces.Services
{
    public interface IMailService
    {
        Task SendAsync(MailRequest request);
    }
}