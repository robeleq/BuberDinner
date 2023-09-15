﻿using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;


namespace BuberDinner.WebApi.Controllers
{
    [Route("/error")]
    public class ErrorsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Error()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            
            return Problem(title: exception?.Message);
        }
    }
}
