using System;
using System.Text.Json;
using System.Threading.Tasks;
using EmailMicroservice.Messages;
using EmailMicroservice.Models;
using EmailMicroservice.Services;
using MessageBroker;

namespace EmailMicroservice.MessageHandlers
{
    public class RegisterEmailHandler : IMessageHandler<RegisterMessage>
    {
        private readonly IEmailService _emailService;

        public RegisterEmailHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }        
        
        public Task HandleMessageAsync(string messageType, RegisterMessage sendable)
        {
            try
            {
                Task.Run(() => { _emailService.SendRegisterEmail(sendable.Email); });
            }
            catch (Exception e)
            {
                Console.WriteLine("The email could not be send   :  " + e );
                throw;
            }
            
            
            return Task.CompletedTask;
        }

        public Task HandleMessageAsync(string messageType, byte[] obj)
        {
            return HandleMessageAsync(messageType, JsonSerializer.Deserialize<RegisterMessage>((ReadOnlySpan<byte>) obj, (JsonSerializerOptions) null));
        }
    }
}