using BuberDinner.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BuberDinner.Application.DTOs.UserProfiles
{
    public class UserProfileResponseDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public Guid UserId { get; set; }
    }
}
