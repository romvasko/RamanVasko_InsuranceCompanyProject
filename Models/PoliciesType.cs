namespace DatabaseSetupProject.Models
{
    public class PoliciesType
    {
        public int Id { get; set; }
        public string PoliciesTypeName { get; set; }
        public virtual ICollection<Policies>? Policies { get; set; }
    }
}
