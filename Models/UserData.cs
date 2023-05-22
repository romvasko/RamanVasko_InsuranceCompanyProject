using Microsoft.AspNetCore.Identity;

namespace DatabaseSetupProject.Models
{
    public class UserData : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
