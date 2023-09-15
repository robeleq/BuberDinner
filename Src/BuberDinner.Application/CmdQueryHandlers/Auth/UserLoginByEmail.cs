using BuberDinner.Application.DTOs.Auth;
using BuberDinner.Application.Errors;
using BuberDinner.Application.Interfaces.Auth;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BuberDinner.Application.CmdQueryHandlers.Auth;

public class UserLoginByEmail
{
    public record Query(string Email, string Password) : IRequest<ErrorOr<AuthResultDTO>>;

    public class QueryHandler : IRequestHandler<Query, ErrorOr<AuthResultDTO>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        private readonly UserManager<IdentityUser> _userManager;

        public QueryHandler(IJwtTokenGenerator jwtTokenGenerator, UserManager<IdentityUser> userManager)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userManager = userManager;
        }

        public async Task<ErrorOr<AuthResultDTO>> Handle(Query request, CancellationToken cancellationToken)
        {
            // Check the user exists
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user is null)
            {
                return UserErrors.EmailNotFound;
            }

            // Check the password is correct
            var result = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!result)
            {
                return new[] { AuthErrors.InvalidCredentials };
            }

            // Get User Roles
            var userRoles = await _userManager.GetRolesAsync(user);

            // Get User Claims
            var userClaims = await _userManager.GetClaimsAsync(user);

            // Create JWT token
            var token = _jwtTokenGenerator.GenerateToken(user, userRoles, userClaims);

            return new AuthResultDTO() { User = user, Token = token};
        }
    }
}