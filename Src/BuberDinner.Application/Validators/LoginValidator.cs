using BuberDinner.Application.CmdQueryHandlers.Auth;
using FluentValidation;

namespace BuberDinner.Application.Validators;

public class LoginValidator : AbstractValidator<LoginByEmail.Query>
{
    public LoginValidator()
    {
        RuleFor(c => c.Email).NotEmpty();
        RuleFor(c => c.Password).NotEmpty();
    }
}
