using BuberDinner.Application.Exceptions;
using System.Net;
using System.Text.Json;


namespace BuberDinner.WebApi.Middlewares;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(context, exception);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var response = context.Response;
        response.ContentType = "application/json";

        switch (exception)
        {
            case AppException e:
                // custom application error
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                break;
            case KeyNotFoundException e:
                // not found error
                response.StatusCode = (int)HttpStatusCode.NotFound;
                break;
            default:
                // unhandled error
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                break;
        }

        var result = JsonSerializer.Serialize(new { message = exception?.Message });

        await response.WriteAsync(result);
    }
}
