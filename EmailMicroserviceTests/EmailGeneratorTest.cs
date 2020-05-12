using EmailMicroservice.Helper;
using Xunit;

namespace EmailMicroserviceTests
{
    public class EmailGeneratorTest
    {
        private readonly EmailGenerator _emailGenerator;

        public EmailGeneratorTest()
        {
            _emailGenerator = new EmailGenerator();
        }
        
        
        [Fact]
        public void CreateRegisterEmailTest()
        {
            //Act
            var email = _emailGenerator.CreateRegisterEmail();

            //Assert
            Assert.NotNull(email);
            Assert.NotNull(email.Body);
            Assert.NotEmpty(email.Body);
            Assert.NotNull(email.Subject);
            Assert.NotEmpty(email.Subject);
        }
    }
}