using BuberDinner.Application.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace BuberDinner.Application.CmdQueryHandlers.Identity
{
    public class CreateUserClaimById
    {
        public record Command(Guid userId, string Name, string Value) : IRequest<ErrorOr<Unit>>;

        public class QueryHandler : IRequestHandler<Command, ErrorOr<Unit>>
        {
            private readonly UserManager<IdentityUser> _userManager;

            private readonly IMapper _mapper;

            public QueryHandler(UserManager<IdentityUser> userManager, IMapper mapper)
            {
                _userManager = userManager;
                _mapper = mapper;
            }

            public async Task<ErrorOr<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByIdAsync(request.userId.ToString());
                if (user == null)
                {
                    return UserErrors.UserNotFound;
                }

                var claim = new Claim(request.Name, request.Value);

                var result = await _userManager.AddClaimAsync(user, claim);

                return Unit.Value;
            }
        }
    }
}
