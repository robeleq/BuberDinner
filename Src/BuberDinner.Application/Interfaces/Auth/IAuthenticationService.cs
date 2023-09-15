using BuberDinner.Domain.Models.Authentication;
using ErrorOr;

namespace BuberDinner.Application.Interfaces.Auth;

public interface IAuthenticationService
{
    ErrorOr<AuthenticationResult> Register(RegisterRequest request);

    ErrorOr<AuthenticationResult> Login(LoginRequest request);
}
