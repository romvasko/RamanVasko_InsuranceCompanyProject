using System.ComponentModel.DataAnnotations;

namespace DatabaseSetupProject.Models
{
    public class CarPolicyViewModel
    {
        public int PoliciesId { get; set; }
        public string UserId { get; set; }
        public int PoliciesStatusId { get; set; }
        public DateTime? PoliciesOrderDateTime { get; set; }
        public decimal Cost { get; set; }
        public bool IsHadAccident { get; set; }

        [Range(18, 120, ErrorMessage = "18 to 120")]
        public int DriverAge { get; set; }
    }
}
