using BuberDinner.Application.DTOs.Accounts;
using BuberDinner.Application.DTOs.Identity.Roles;
using BuberDinner.Domain.Entities;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Rewrite;

namespace BuberDinner.Application.CmdQueryHandlers.Identity
{
    public class GetRoles
    {
        public record Query() : IRequest<IEnumerable<RoleResponseDto>>;

        public class QueryHandler : IRequestHandler<Query, IEnumerable<RoleResponseDto>>
        {
            private readonly RoleManager<IdentityRole> _roleManger;

            private readonly IMapper _mapper;
            public QueryHandler(RoleManager<IdentityRole> roleManger, IMapper mapper)
            {
                _roleManger = roleManger;
                _mapper = mapper;
            }

            public async Task<IEnumerable<RoleResponseDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                await Task.CompletedTask;

                var roles = _roleManger.Roles;

                return _mapper.Map<IEnumerable<RoleResponseDto>>(roles);
            }
        }
    }
}
