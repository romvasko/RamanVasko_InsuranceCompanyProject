namespace DatabaseSetupProject.Models
{
    public class BankPaymentPolicyOrder
    {
        public int Id { get; set; }
        public int PoliciesOrderId { get; set; }
        public int BankPaymentId { get; set; }
        public PoliciesOrder? PoliciesOrder { get; set; }
        public BankPayment? BankPayment { get; set; }
    }
}
