using BuberDinner.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace BuberDinner.Application.Interfaces.Auth;

public interface IJwtTokenGenerator
{
    string GenerateToken(IdentityUser user, IList<string> userRoles, IList<Claim> userClaims);
}
