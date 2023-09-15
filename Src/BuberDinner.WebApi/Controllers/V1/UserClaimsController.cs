using BuberDinner.Application.CmdQueryHandlers.Identity;
using BuberDinner.Application.DTOs.Identity.Claims;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.WebApi.Controllers.V1
{

    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/users/{userId:guid}/claims")]
    [AllowAnonymous]
    public class UserClaimsController : BaseApiController
    {

        private readonly IMediator _mediator;

        private readonly IMapper _mapper;

        public UserClaimsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserClaimsByUserId(Guid userId, CancellationToken cancellationToken)
        {
            var query = new GetAllUserClaimsByUserId.Query(userId);

            ErrorOr<List<string>> results = await _mediator.Send(query);

            return results.Match(
              result => Ok(results.Value),
              errors => Problem(errors));
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateUserClaimById(Guid userId, [FromBody] ClaimRequestDto request, CancellationToken cancellationToken)
        {
            var command = new CreateUserClaimById.Command(userId, request.Name, request.Value);

            ErrorOr<Unit> result = await _mediator.Send(command);

            return result.Match(
               result => NoContent(),
               errors => Problem(errors));
        }
    }
}
