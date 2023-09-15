using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.WebApi.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/dinners")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
    public class DinnerController : BaseApiController
    {
        [HttpGet]
        [Authorize(Policy = "CanCreateUserPolicy")]
        public IActionResult ListDinners()
        {
            return Ok(Array.Empty<string>());
        }
    }
}
