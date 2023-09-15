using BuberDinner.Application.Errors;
using BuberDinner.Application.Interfaces;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BuberDinner.Application.CmdQueryHandlers.Identity
{
    public class CreateUserRoleById
    {
        public record Command(Guid userId, Guid roleId) : IRequest<ErrorOr<Unit>>;

        public class QueryHandler : IRequestHandler<Command, ErrorOr<Unit>>
        {
            private readonly UserManager<IdentityUser> _userManager;

            private readonly RoleManager<IdentityRole> _roleManager;

            private readonly IMapper _mapper;
            public QueryHandler(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
            {
                _userManager = userManager;
                _roleManager = roleManager;
                _mapper = mapper;
            }

            public async Task<ErrorOr<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByIdAsync(request.userId.ToString());
                if (user == null)
                {
                    return UserErrors.UserNotFound;
                }

                var role = await _roleManager.FindByIdAsync(request.roleId.ToString());
                if (role == null)
                {
                    return RoleErrors.RoleNotFound;
                }

                var userRoles = await _userManager.GetRolesAsync(user);
                if (userRoles.Contains(role.Name))
                {
                    return RoleErrors.DuplicateRole;
                }

                var result = await _userManager.AddToRoleAsync(user, role.Name);

                return Unit.Value;
            }
        }
    }
}
