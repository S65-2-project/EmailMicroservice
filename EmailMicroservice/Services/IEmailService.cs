using System.Threading.Tasks;

namespace EmailMicroservice.Services
{
    public interface IEmailService
    {
        Task SendWelcomeEmail(string emailAddress);
        Task SendEmail(string emailAddress, int emailType);
    }
}