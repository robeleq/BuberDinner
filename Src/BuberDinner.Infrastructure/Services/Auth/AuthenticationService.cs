using BuberDinner.Application.Errors;
using BuberDinner.Application.Interfaces.Auth;
using BuberDinner.Application.Interfaces.Users;
using BuberDinner.Domain.Entities;
using BuberDinner.Domain.Models.Authentication;
using ErrorOr;
using FluentResults;

namespace BuberDinner.Infrastructure.Services.Auth;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository2 _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository2 userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public ErrorOr<AuthenticationResult> Login(LoginRequest request)
    {
        throw new NotImplementedException();
    }

    public ErrorOr<AuthenticationResult> Register(RegisterRequest request)
    {
        throw new NotImplementedException();
    }


    /*
    public ErrorOr<AuthenticationResult> Login(LoginRequest request)
    {
        // Check the user exists
        if(_userRepository.GetUserByEmail(request.Email) is not AppUser user) 
        {
            // throw new KeyNotFoundException("User with the given email does not exist.");
            return UserErrors.EmailNotFound;
        }

        // Check the password is correct
        if(user.Password != request.Password) 
        {
            // throw new AppException("Invalid Email or Password.");
            // return Errors.Auth.InvalidCredentials;
            return new [] { AuthErrors.InvalidCredentials };
        }

        // Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        // TODO: refractor call from Domain
        return new AuthenticationResult(user, token);
    }

    public ErrorOr<AuthenticationResult> Register(RegisterRequest request)
    {
        // Check if the user doesn't exist
        if(_userRepository.GetUserByEmail(request.Email) is not null)
        {
            // throw new Exception("User with the given email already exists.");
            // return FluentResults.Result.Fail<AuthenticationResult>(new[] { new DuplicateEmailError() });
            return AuthErrors.DuplicateEmail;
        }

        // Create a new user 
        var user = new AppUser 
        {                   
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = request.Password,
        };

        // Persist the user
        _userRepository.AddUser(user);

        // Create JWT token
        // var userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
    */
}