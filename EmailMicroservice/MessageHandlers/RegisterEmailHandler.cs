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
            _emailService.SendRegisterEmail(sendable.Email);
            return Task.CompletedTask;
        }

        public Task HandleMessageAsync(string messageType, byte[] obj)
        {
            return HandleMessageAsync(messageType, JsonSerializer.Deserialize<RegisterMessage>((ReadOnlySpan<byte>) obj, (JsonSerializerOptions) null));
        }
    }
}