using BuberDinner.Application.CmdQueryHandlers.Identity;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.WebApi.Controllers.V1
{

    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/users/{userId:guid}/roles")]
    [AllowAnonymous]
    public class UserRolesController : BaseApiController
    {

        private readonly IMediator _mediator;

        private readonly IMapper _mapper;

        public UserRolesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetRolesByUserId(Guid userId, CancellationToken cancellationToken)
        {
            var query = new GetAllRolesByUserId.Query(userId);

            ErrorOr<List<string>> results = await _mediator.Send(query);

            return results.Match(
              result => Ok(results.Value),
              errors => Problem(errors));
        }

        [HttpPost("{roleId:guid}")]
        public async Task<IActionResult> CreateUserRoleById(Guid userId, Guid roleId, CancellationToken cancellationToken)
        {
            var command = new CreateUserRoleById.Command(userId, roleId);

            ErrorOr<Unit> result = await _mediator.Send(command);

            return result.Match(
               result => NoContent(),
               errors => Problem(errors));
        }
    }
}
