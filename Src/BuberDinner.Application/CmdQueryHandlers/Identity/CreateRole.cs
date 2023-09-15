using BuberDinner.Application.DTOs.Accounts;
using BuberDinner.Application.DTOs.Identity.Roles;
using BuberDinner.Application.Errors;
using BuberDinner.Application.Interfaces;
using BuberDinner.Domain.Entities;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.CmdQueryHandlers.Identity
{
    public class CreateRole
    {
        public record Command(String Name) : IRequest<ErrorOr<RoleResponseDto>>;

        public class CommandHandler : IRequestHandler<Command, ErrorOr<RoleResponseDto>>
        {
            private readonly RoleManager<IdentityRole> _roleManager;
            private readonly IMapper _mapper;

            public CommandHandler(RoleManager<IdentityRole> roleManager, IMapper mapper)
            {
                _roleManager = roleManager;
                _mapper = mapper;
            }

            public async Task<ErrorOr<RoleResponseDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                var isRoleExist = await _roleManager.RoleExistsAsync(request.Name);
                if (isRoleExist)
                {
                    return RoleErrors.DuplicateRole;
                }

                var role = new IdentityRole
                {
                    Name = request.Name
                };

                await _roleManager.CreateAsync(role);

                var roleResponseDTO = _mapper.Map<RoleResponseDto>(role);

                return roleResponseDTO;
            }
        }
    }
}
