using EmailMicroservice.Models;

namespace EmailMicroservice.Helper
{
    public class EmailGenerator : IEmailGenerator
    {
        public Email CreateRegisterEmail() {
            var message = new Email
            {
                Subject = "Welcome to the Lisk Marketplace!",
                Body =
                    "style=\"color: #000000;\">Welcome to the Lisk Marketplace!</span></h1>\n<h2 style=\"color: #2e6c80;\"><span style=\"color: #000000;\">You have succesfully created an account on our platform! We hope you have tons of fun.</span></h2>\n<p>&nbsp;</p>"
            };
            return message;
        }
    }
}