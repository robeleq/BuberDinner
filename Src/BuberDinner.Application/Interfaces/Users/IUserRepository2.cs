using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Interfaces.Users;

public interface IUserRepository2
{
    AppUser? GetUserByEmail(string email);

    void AddUser(AppUser user);
}
