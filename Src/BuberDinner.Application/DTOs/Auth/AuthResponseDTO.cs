namespace BuberDinner.Application.DTOs.Auth
{
    public class AuthResponseDTO
    {
        public Guid Id { get; set; }

        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Token { get; set; } = null!;
    }
}
