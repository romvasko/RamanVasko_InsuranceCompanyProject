namespace DatabaseSetupProject.Models
{
    public class PoliciesStatus
    {
        public int Id { get; set; }
        public string StatusName { get; set; }
        public virtual ICollection<PoliciesOrder>? PoliciesOrders { get; set; }
    }
}
