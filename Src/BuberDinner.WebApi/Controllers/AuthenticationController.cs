using BuberDinner.Application.Errors;
using BuberDinner.Application.CmdQueryHandlers.Auth;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using BuberDinner.Application.DTOs.Auth;
using BuberDinner.Application.DTOs.Identity.Roles;
using BuberDinner.Application.DTOs.Identity.Users;

namespace BuberDinner.WebApi.Controllers
{
    [Route("api/autha")]
    [AllowAnonymous]
    public class AuthenticationController : BaseApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AuthenticationController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginRequestDto request)
        {
            // ErrorOr<AuthenticationResult> result = _authenticationService.Login(request);
            var query = _mapper.Map<LoginByEmail.Query>(request);

            // ErrorOr<AuthenticationResult> result = await _mediator.Send(query);
            ErrorOr<AuthResultDTO> result = await _mediator.Send(query);
           
            if (result.IsError && result.FirstError == AuthErrors.InvalidCredentials) 
            {
                return Problem(
                    statusCode: StatusCodes.Status401Unauthorized,
                    title: result.FirstError.Description);
            }

            // TODO: refractor call from Domain <AuthenticationResponse>
            return result.Match(
                result => Ok(_mapper.Map<RoleResponseDto>(result)),
                errors => Problem(errors));
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegistrationRequestDto request)
        {
            // ErrorOr<AuthenticationResult> result = _authenticationService.Register(request);

            var command = _mapper.Map<Register.Command>(request);

            // ErrorOr<AuthenticationResult> result = await _mediator.Send(command);
            ErrorOr<AuthResultDTO> result = await _mediator.Send(command);

            return result.Match(
                result => Ok(_mapper.Map<RoleResponseDto>(result)),
                errors => Problem(errors));
        }
    }
}
