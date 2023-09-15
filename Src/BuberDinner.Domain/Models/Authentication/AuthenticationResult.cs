using BuberDinner.Domain.Entities;

namespace BuberDinner.Domain.Models.Authentication;

public record AuthenticationResult(
    AppUser User,
    string Token
);

