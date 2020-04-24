using System.ComponentModel.DataAnnotations;

namespace EmailMicroservice.Models
{
    public class Sendable
    {
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public int emailType { get; set; }
    }
}