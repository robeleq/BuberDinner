using BuberDinner.Application.CmdQueryHandlers.Identity;
using BuberDinner.Application.DTOs.Identity.Roles;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.WebApi.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/roles")]
    [AllowAnonymous]
    public class RolesController : BaseApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public RolesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles(CancellationToken cancellationToken)
        {
            var query = new GetRoles.Query();

            IEnumerable<RoleResponseDto> results = await _mediator.Send(query);

            return Ok(_mapper.Map<IEnumerable<RoleResponseDto>>(results));
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] RoleRequestDto request, CancellationToken cancellationToken)
        {
            var command = new CreateRole.Command(request.Name);
          
            ErrorOr<RoleResponseDto> result = await _mediator.Send(command);

            return result.Match(
                result => Ok(_mapper.Map<RoleResponseDto>(result)),
                errors => Problem(errors));
        }
    }
}
