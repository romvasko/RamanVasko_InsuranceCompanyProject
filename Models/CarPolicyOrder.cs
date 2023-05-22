using System.ComponentModel.DataAnnotations;

namespace DatabaseSetupProject.Models
{
    [Serializable]
    public class CarPolicyOrder
    {
        public int Id { get; set; }
        public int PoliciesOrderId { get; set; }
        public int CarPolicyConditionId { get; set; }
        public PoliciesOrder? PoliciesOrder {get; set;}
        public CarPolicyCondition? CarPolicyCondition {get; set;}

    }
}
