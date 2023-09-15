using BuberDinner.Application.DTOs.Accounts;
using BuberDinner.Application.DTOs.Auth;
using BuberDinner.Application.Errors;
using BuberDinner.Domain.Entities;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Rewrite;

namespace BuberDinner.Application.CmdQueryHandlers.Identity
{
    public class GetAllRolesByUserId
    {
        public record Query(Guid userId) : IRequest<ErrorOr<List<string>>>;

        public class QueryHandler : IRequestHandler<Query, ErrorOr<List<string>>>
        {
            private readonly UserManager<IdentityUser> _userManager;

            private readonly IMapper _mapper;
            public QueryHandler(UserManager<IdentityUser> userManager, IMapper mapper)
            {
                _userManager = userManager;
                _mapper = mapper;
            }

            public async Task<ErrorOr<List<string>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByIdAsync(request.userId.ToString());
                if (user == null) 
                {
                    return UserErrors.UserNotFound;
                }

                var roles = await _userManager.GetRolesAsync(user);

                return _mapper.Map<List<string>>(roles);
            }
        }
    }
}
