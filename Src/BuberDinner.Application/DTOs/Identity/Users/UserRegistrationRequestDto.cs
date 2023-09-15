namespace BuberDinner.Application.DTOs.Identity.Users
{
    public class UserRegistrationRequestDto
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string ConfirmPassword { get; set; } = null!;
    }
}
