using BuberDinner.Application.DTOs.Auth;
using BuberDinner.Application.Errors;
using BuberDinner.Application.Interfaces;
using BuberDinner.Application.Interfaces.Auth;
using BuberDinner.Domain.Entities;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.CmdQueryHandlers.Auth;

public class Register
{
    public record Command(string FirstName, string LastName, string Email, string Password) : IRequest<ErrorOr<AuthResultDTO>>;

    public class CommandHandler : IRequestHandler<Command, ErrorOr<AuthResultDTO>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IRepositoryManager _repositoryManager;

        public CommandHandler(IJwtTokenGenerator jwtTokenGenerator, IRepositoryManager repositoryManager)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _repositoryManager = repositoryManager;
        }

        public Task<ErrorOr<AuthResultDTO>> Handle(Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /*public async Task<ErrorOr<AuthResultDTO>> Handle(Command request, CancellationToken cancellationToken)
        {
            // Check if the user doesn't exist
            if (await _repositoryManager.UserRepository.GetUserByEmailAsync(request.Email, cancellationToken) is not null)
            {
                return AuthErrors.DuplicateEmail;
            }

            // Create a new user 
            var user = new AppUser
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password,
            };

            // Persist the user
            _repositoryManager.UserRepository.CreateUser(user);

            await _repositoryManager.SaveChangesAsync(cancellationToken);

            // Create JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthResultDTO() { User = user, Token = token};
        }
        */
    }
}
