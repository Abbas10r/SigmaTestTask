using System.ComponentModel.DataAnnotations;

namespace SigmaTestTask.Models
{
    public class CandidateDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public DateTime TimeInterval { get; set; }
        [Url]
        public string LinkedinUrl { get; set; }
        [Url]
        public string GithubUrl { get; set; }
        [Required]
        public string Comment { get; set; }
    }
}
