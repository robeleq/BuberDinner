using FluentResults;

namespace BuberDinner.Application.Errors;

public class DuplicateEmailError : IError
{
    public List<IError> Reasons => throw new NotImplementedException();

    public string Message => "Email Already Exists";

    public Dictionary<string, object> Metadata => throw new NotImplementedException();
}
