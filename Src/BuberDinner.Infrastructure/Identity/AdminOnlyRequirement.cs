using Microsoft.AspNetCore.Authorization;

namespace BuberDinner.Infrastructure.Identity
{
    public class AdminOnlyRequirement : IAuthorizationRequirement
    {
        public AdminOnlyRequirement(bool adminOnly) =>
            AdminOnly = adminOnly;

        public bool AdminOnly { get; }
    }
}
