using EmailMicroservice.Models;

namespace EmailMicroservice.Helper
{
    public interface IEmailGenerator
    {
        /// <summary>
        /// Creates an email object for the register action
        /// </summary>
        /// <returns>Email object with a body and subject</returns>
        Email CreateRegisterEmail();
    }
}