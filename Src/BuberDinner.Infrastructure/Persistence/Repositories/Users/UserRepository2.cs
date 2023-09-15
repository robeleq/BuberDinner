using BuberDinner.Application.Interfaces.Users;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Infrastructure.Data.Repositories.Users;

public class UserRepository2 : IUserRepository2
{
    private static readonly List<AppUser> _users = new List<AppUser>();

    public void AddUser(AppUser user)
    {
        _users.Add(user);
    }

    public AppUser? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(u => u.Email == email);
    }
}
