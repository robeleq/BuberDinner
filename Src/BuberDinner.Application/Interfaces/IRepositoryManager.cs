using BuberDinner.Application.Interfaces.Users;

namespace BuberDinner.Application.Interfaces
{
    // interface that acts as a wrapper	
    public interface IRepositoryManager
    {
        IUserRepository UserRepository { get; }

        IAccountRepository AccountRepository { get; }

        IUserProfileRepository UserProfileRepository { get; }

        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
