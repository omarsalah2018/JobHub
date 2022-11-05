using System.ComponentModel.DataAnnotations;

namespace JobHub.Domain.Entities
{
    public class Candidate
    {
        public string Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        public string CallTimeFrom { get; set; }
        public string CallTimeTo { get; set; }
        public string LinkedInProfileURL { get; set; }
        public string GitHubProfileURL { get; set; }
        [Required]
        public string Comment { get; set; }


    }
}
