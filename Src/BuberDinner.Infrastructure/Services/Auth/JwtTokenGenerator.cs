using BuberDinner.Application.Interfaces;
using BuberDinner.Application.Interfaces.Auth;
using BuberDinner.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BuberDinner.Infrastructure.Services.Auth;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly JwtSettings _jwtSettings;

    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtSettings)
    { 
        _dateTimeProvider = dateTimeProvider;
        _jwtSettings = jwtSettings.Value;
    }
    public string GenerateToken(IdentityUser user, IList<string> userRoles, IList<Claim> userClaims)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
            SecurityAlgorithms.HmacSha256);

        IdentityOptions _options = new IdentityOptions();

        var claims = new List<Claim>
        {
            new Claim("Id", user.Id),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(_options.ClaimsIdentity.UserIdClaimType, user.Id.ToString()),
            new Claim(_options.ClaimsIdentity.UserNameClaimType, user.UserName),
            // new Claim(ClaimTypes.Role, "Administrator"),
        };

        foreach (string role in userRoles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));

            /*var role = await _roleManager.FindByNameAsync(userRole);
            if (role != null)
            {
                var roleClaims = await _roleManager.GetClaimsAsync(role);
                foreach (Claim roleClaim in roleClaims)
                {
                    claims.Add(roleClaim);
                }
            }*/
        }

        foreach (Claim claim in userClaims)
        {
            claims.Add(claim);
        }

        var securityToken = new JwtSecurityToken(
            issuer:  _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
            claims: claims,
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}
