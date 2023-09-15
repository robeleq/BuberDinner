using BuberDinner.Application.CmdQueryHandlers.Accounts;
using BuberDinner.Application.CmdQueryHandlers.UserProfiles;
using BuberDinner.Application.DTOs.Accounts;
using BuberDinner.Application.DTOs.UserProfiles;
using BuberDinner.WebApi.Controllers;
using ErrorOr;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnionArch.Presentation.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/users/{userId:guid}/profiles")]
    [AllowAnonymous]
    public class UserProfileController : BaseApiController
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UserProfileController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserProfile(Guid userId, CancellationToken cancellationToken)
        {
            var query = new GetUserProfileByUserId.Query(userId);

            ErrorOr<UserProfileResponseDto> result = await _mediator.Send(query);

            return result.Match(
              result => Ok(_mapper.Map<UserProfileResponseDto>(result)),
              errors => Problem(errors));
        }

        [HttpGet("{profileId:guid}")]
        public async Task<IActionResult> GetUserProfileById(Guid userId, Guid profileId, CancellationToken cancellationToken)
        {
            /*var query = new GetUserProfileByProfileId.Query(userId, profileId);

            ErrorOr<UserProfileResponseDto> result = await _mediator.Send(query);

            return result.Match(
               result => Ok(_mapper.Map<UserProfileResponseDto>(result)),
               errors => Problem(errors));*/

            await Task.CompletedTask;

            return Ok();
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateUserProfile(Guid userId, [FromBody] UserProfileRequestDto request, CancellationToken cancellationToken)
        {          
            var command = new CreateUserProfile.Command(
                userId,
                request.FirstName, 
                request.LastName, 
                request.PhoneNumber, 
                request.City, 
                request.Address, 
                request.State);

            ErrorOr<UserProfileResponseDto> result = await _mediator.Send(command);

            return result.Match(
                result => Ok(_mapper.Map<UserProfileResponseDto>(result)),
                errors => Problem(errors));
        }
        
        [HttpDelete("{profileId:guid}")]
        public async Task<IActionResult> DeleteUserProfile(Guid userId, Guid accountId, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            return Ok();
        }
    }
}
