using ErrorOr;

namespace BuberDinner.Application.Errors;

public static class UserErrors
{
    public static Error EmailNotFound => Error.NotFound(
        code: "User.EmailNotFound",
        description: "Email does not exist.");

    public static Error UserNotFound => Error.NotFound(
        code: "User.UserNotFound",
        description: "User does not exist.");
}
