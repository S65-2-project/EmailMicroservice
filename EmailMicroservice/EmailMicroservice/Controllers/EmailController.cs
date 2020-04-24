using System;
using System.Threading.Tasks;
using EmailMicroservice.Models;
using EmailMicroservice.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmailMicroservice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _email;
        
        public EmailController(IEmailService email)
        {
            _email = email;
        }
        
        [HttpPost("")]
        public async Task<IActionResult> SendEmail(Sendable send)
        {
            try
            {
                await _email.SendEmail(send.EmailAddress, send.emailType);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }
    }
}