using System.Threading.Tasks;

namespace EmailMicroservice.Services
{
    public interface IEmailService
    { 
        /// <summary>
        /// Sends the Register email to the given email address
        /// </summary>
        /// <param name="email">email address to send the email to</param>
        /// <returns>Task to send the email</returns>
        Task SendRegisterEmail(string email);
    }
}