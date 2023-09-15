using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Interfaces.Users
{
    public interface IUserProfileRepository : IRepositoryBase<UserProfile>
    {
        Task<IEnumerable<UserProfile>> GetAllUserProfilesAsync(CancellationToken cancellationToken = default);

        Task<UserProfile?> GetUserProfileByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);

        Task<UserProfile?> GetUserProfileByProfileIdAsync(Guid profileId, CancellationToken cancellationToken = default);

        void CreateUserProfile(UserProfile profile);

        void UpdateUserProfile(UserProfile profile);

        void DeleteUserProfile(UserProfile profile);
    }
}
