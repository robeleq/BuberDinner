using BuberDinner.Application.DTOs.Auth;
using BuberDinner.Application.Errors;
using BuberDinner.Application.Interfaces;
using BuberDinner.Application.Interfaces.Auth;
using BuberDinner.Domain.Entities;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BuberDinner.Application.CmdQueryHandlers.Auth;

public class UserRegister
{
    public record Command(string FirstName, string LastName, string Email, string Password, string ConfirmPassword) : IRequest<ErrorOr<AuthResultDTO>>;

    public class CommandHandler : IRequestHandler<Command, ErrorOr<AuthResultDTO>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly UserManager<IdentityUser> _userManager;

        public CommandHandler(IJwtTokenGenerator jwtTokenGenerator, UserManager<IdentityUser> userManager)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userManager = userManager;
        }

        public async Task<ErrorOr<AuthResultDTO>> Handle(Command request, CancellationToken cancellationToken)
        {
            // Check comfirm password
            if (request.Password != request.ConfirmPassword)
            {
                return AuthErrors.InvalidConfirmPassword;
            }

            // Create a new user 
            var user = new IdentityUser
            {
                Email = request.Email,
                UserName = request.FirstName + request.LastName,
            };

            // Persist the user
            var result = await _userManager.CreateAsync(user, request.Password);

            List<Error> errors = new();
            if (!result.Succeeded) 
            {
                foreach(IdentityError error in result.Errors) 
                {
                   var e = Error.Validation(
                       code: error.Code,
                       description: error.Description
                   );
                   errors.Add(e);
                }
                return errors.ToArray();
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
