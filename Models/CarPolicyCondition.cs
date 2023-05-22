using System.ComponentModel.DataAnnotations;

namespace DatabaseSetupProject.Models
{
    public class CarPolicyCondition
    {
        public int id { get; set; }
        public bool IsHadAccident { get; set; }
        [Range(18, 120, ErrorMessage = "18 to 120")]
        public int DriverAge { get; set; }
        public ICollection<CarPolicyOrder> CarPolicyOrders { get; set; }
    }
}
