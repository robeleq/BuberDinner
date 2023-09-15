using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.WebApi.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/dinners")]
    [AllowAnonymous]
    public class DinnerController : BaseApiController
    {
        [HttpGet]
        public IActionResult ListDinners()
        {
            return Ok(Array.Empty<string>());
        }
    }
}
