using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EmailMicroservice.Services
{
    public class EmailService : IEmailService
    {
        private string _liskEmail = "s652.lisk@gmail.com";
        private string _liskPassword = "82VrL!8o!Q-P68UpWRp3pZd2m2Nc*a2Am7";

        public Task SendEmail(string emailAddress, int emailType)
        {
            return emailType switch
            {
                1 => SendWelcomeEmail(emailAddress),
                _ => throw new ArgumentException("Something went wrong: ")
            };
        }
        
        public async Task SendWelcomeEmail(string emailAddress)
        {
            var client = new SmtpClient("smtp.gmail.com", 465)
            {
                Credentials = new NetworkCredential(_liskEmail, _liskPassword),
                EnableSsl = true
            };
            var mail = new MailMessage(_liskEmail, emailAddress, "Welcome to the LiskMarketplace", "bruh") {IsBodyHtml = true};

            try
            {
                using (client)
                {
                    client.Send(mail);
                    await client.SendMailAsync(mail);
                }
            }
            catch (SmtpException e)
            {
                throw new ArgumentException("Failed sending Email: "  + e.Message);
            }
        }
    }
}