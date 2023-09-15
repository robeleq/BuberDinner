using BuberDinner.Application.CmdQueryHandlers.Identity;
using BuberDinner.Application.DTOs.Identity.Roles;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.WebApi.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/greetings")]
    [AllowAnonymous]
    public class GreetingController : BaseApiController
    {
        public GreetingController()
        {
          
        }

        [HttpGet("morning")]
        public ActionResult GetMorningMessages(CancellationToken cancellationToken)
        {
            return Ok("Good Morning From ASP .NET Core 6.0");
        }

    }
}
