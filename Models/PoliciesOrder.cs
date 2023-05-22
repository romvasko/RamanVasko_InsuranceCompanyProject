using System.ComponentModel.DataAnnotations;

namespace DatabaseSetupProject.Models
{

    public class PoliciesOrder
    {
        public int Id { get; set; }
        public int PoliciesId { get; set; }
        public string UserId { get; set; }
        public int PoliciesStatusId { get; set; }
        public DateTime PoliciesOrderDateTime { get; set; }
        public decimal Cost { get; set; }
        [StringLength(1000)]
        public virtual PoliciesStatus? PoliciesStatus { get; set; }
        public virtual Policies? Policies { get; set; }
        public ICollection<InsuranceCase>? InsuranceCases { get; set; }
        public ICollection<CarPolicyOrder>? CarPolicyOrders { get; set; }
        public ICollection<BankPaymentPolicyOrder>? bankPaymentPolicyOrders { get; set; }
    }
}
