using BuberDinner.Application.CmdQueryHandlers.Auth;
using BuberDinner.Application.DTOs.Auth;
using BuberDinner.Application.DTOs.Identity.Users;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.WebApi.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/auth")]
    [AllowAnonymous]
    public class AuthController : BaseApiController
    {
        private readonly IMediator _mediator;

        private readonly IMapper _mapper;

        public AuthController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequestDto request)
        {
            var command = _mapper.Map<UserLoginByEmail.Query>(request);

            ErrorOr<AuthResultDTO> result = await _mediator.Send(command);

            return result.Match(
                result => Ok(_mapper.Map<AuthResponseDTO>(result)),
                errors => Problem(errors));
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequestDto request)
        {
            var command = _mapper.Map<UserRegister.Command>(request);

            ErrorOr<AuthResultDTO> result = await _mediator.Send(command);

            return result.Match(
                result => Ok(_mapper.Map<AuthResponseDTO>(result)),
                errors => Problem(errors));
        }
    }
}
