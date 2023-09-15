using Microsoft.AspNetCore.Identity;

namespace BuberDinner.Domain.Entities
{
    public class UserProfile
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string City { get; set; }
        
        public string State { get; set; }

        public IdentityUser User { get; set; }
    }
}
