using System.ComponentModel.DataAnnotations;

namespace DatabaseSetupProject.Models
{
    public class BankPaymentViewModel
    {
        public int PolicyOrderId { get; set; }
        [StringLength(16)]
        public string CardNumber { get; set; } 
    }
}
