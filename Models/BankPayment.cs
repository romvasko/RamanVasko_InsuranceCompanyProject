namespace DatabaseSetupProject.Models
{
    public class BankPayment
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public ICollection<BankPaymentPolicyOrder>? bankPaymentPolicyOrders { get; set; }
    }
}
