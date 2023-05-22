using Microsoft.AspNetCore.Identity;

namespace DatabaseSetupProject.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime StartWorking { get; set; } 
        public decimal Salary { get; set; }
        public virtual IdentityUser? User { get; set; }

    }
}
