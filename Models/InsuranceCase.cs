using System.ComponentModel.DataAnnotations;

namespace DatabaseSetupProject.Models
{
    public class InsuranceCase
    {
        public int Id { get; set; }
        [Phone(ErrorMessage = "Phone for response")]
        public string PhoneNumber { get; set; }
        [MaxLength(1000)]
        public string InsuranceCaseDescription { get; set; }
        public string UserId { get; set; }
    }
}
