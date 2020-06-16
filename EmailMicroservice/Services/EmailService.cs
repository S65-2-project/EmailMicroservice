using System;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using EmailMicroservice.Helper;
using EmailMicroservice.Models;
using Microsoft.Extensions.Options;

namespace EmailMicroservice.Services
{
    public class EmailService : IEmailService
    {

        private readonly EmailSettings _mailSettings;
        private readonly IEmailGenerator _emailGenerator;
        
        public EmailService(IOptions<EmailSettings> mailSettings, IEmailGenerator emailGenerator)
        {
            _mailSettings = mailSettings.Value;
            _emailGenerator = emailGenerator;
        }
        
        public async Task SendRegisterEmail(string email)
        {
            await SendEmail(email, _emailGenerator.CreateRegisterEmail());
        }
        
        private async Task SendEmail(string to, Email email)
        {
            var mail = new MailMessage
            {
                From = new MailAddress(_mailSettings.Email),
            };
            
            mail.To.Add(new MailAddress(to));
            mail.Subject = email.Subject;
            mail.Body = email.Body;
            mail.IsBodyHtml = true;

            using var smtp = new SmtpClient(_mailSettings.Host, _mailSettings.Port)
            {
                Credentials = new NetworkCredential(_mailSettings.Email, _mailSettings.Password), 
                EnableSsl = _mailSettings.Ssl
            };
            
            await smtp.SendMailAsync(mail);
        }
    }
}