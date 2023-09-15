using ErrorOr;

namespace BuberDinner.Application.Errors;

public static class RoleErrors
{
    public static Error RoleNotFound => Error.NotFound(
        code: "Role.RoleNotFound",
        description: "Role does not exist.");

    public static Error DuplicateRole => Error.Conflict(
             code: "Role.DuplicateRole",
             description: "Role Already Exists");

}
