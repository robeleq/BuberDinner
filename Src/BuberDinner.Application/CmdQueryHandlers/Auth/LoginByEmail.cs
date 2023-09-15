using BuberDinner.Application.DTOs.Auth;
using BuberDinner.Application.Errors;
using BuberDinner.Application.Interfaces;
using BuberDinner.Application.Interfaces.Auth;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.CmdQueryHandlers.Auth;

public class LoginByEmail
{
    // public record Query(string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;
    public record Query(string Email, string Password) : IRequest<ErrorOr<AuthResultDTO>>;

    // public class QueryHandler : IRequestHandler<Query, ErrorOr<AuthenticationResult>>
    public class QueryHandler : IRequestHandler<Query, ErrorOr<AuthResultDTO>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IRepositoryManager _repositoryManager;

        public QueryHandler(IJwtTokenGenerator jwtTokenGenerator, IRepositoryManager repositoryManager)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _repositoryManager = repositoryManager;
        }

        public Task<ErrorOr<AuthResultDTO>> Handle(Query request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        // public async Task<ErrorOr<AuthenticationResult>> Handle(Query request, CancellationToken cancellationToken)
        /* public async Task<ErrorOr<AuthResultDTO>> Handle(Query request, CancellationToken cancellationToken)
        {
            // Check the user exists
            var user = await _repositoryManager.UserRepository.GetUserByEmailAsync(request.Email, cancellationToken);

            if (user is null)
            {
                return UserErrors.EmailNotFound;
            }

            // Check the password is correct
            if (user.Password != request.Password)
            {
                return new[] { AuthErrors.InvalidCredentials };
            }

            // Create JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);

            // return new AuthenticationResult(user, token)
            return new AuthResultDTO() { User = user, Token = token};
        }*/
    }
}