using BuberDinner.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BuberDinner.Application.Interfaces.Users
{
    public interface IUserRepository : IRepositoryBase<AppUser>
    // public interface IUserRepository
    {
        Task<IEnumerable<AppUser>> GetAllUsersAsync(CancellationToken cancellationToken = default);

        Task<AppUser?> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken = default);

        Task<AppUser?> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default);

        void CreateUser(AppUser user);

        void UpdateUser(AppUser user);

        void DeleteUser(AppUser user);
    }
}
