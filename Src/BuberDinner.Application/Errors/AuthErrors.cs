using ErrorOr;

namespace BuberDinner.Application.Errors;


public static class AuthErrors
{
    public static Error InvalidCredentials => Error.Validation(
        code: "Auth.InvalidCredentials",
        description: "Invalid Email or Password");

    public static Error DuplicateEmail => Error.Conflict(
            code: "Auth.DuplicateEmail",
            description: "Email Already Exists");

    public static Error InvalidConfirmPassword => Error.Validation(
        code: "Auth.InvalidConfirmPassword",
        description: "ConfirmPassword Don't Match the Password");
    
}

