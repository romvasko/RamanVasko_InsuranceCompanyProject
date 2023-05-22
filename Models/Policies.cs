using Microsoft.AspNetCore.Identity;

namespace DatabaseSetupProject.Models
{

    public class Policies
    {
        public int Id { get; set; }
        public string PoliciesName { get; set; }
        public string PoliciesDescription { get; set; }
        public decimal BaseCost { get; set; }
        public int PoliciesTypeId { get; set; }
        public virtual PoliciesType? PoliciesType { get; set; }
    }

}
