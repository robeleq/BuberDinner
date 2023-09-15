using BuberDinner.Application.Interfaces.Users;
using BuberDinner.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BuberDinner.Infrastructure.Persistence.Repositories.Users
{
    internal sealed class UserProfileRepository : RepositoryBase<UserProfile>, IUserProfileRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserProfileRepository(ApplicationDbContext dbContext)
           : base(dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<IEnumerable<UserProfile>> GetAllUserProfilesAsync(CancellationToken cancellationToken = default) =>
            await _dbContext.UserProfiles.Include(x => x.User).ToListAsync(cancellationToken);

        public async Task<UserProfile?> GetUserProfileByUserIdAsync(Guid userId, CancellationToken cancellationToken = default) =>
            await _dbContext.UserProfiles.Include(x => x.User).FirstOrDefaultAsync(x => x.User.Id == userId.ToString(), cancellationToken);

        public async Task<UserProfile?> GetUserProfileByProfileIdAsync(Guid profileId, CancellationToken cancellationToken = default) =>
            await _dbContext.UserProfiles.FirstOrDefaultAsync(x => x.Id == profileId, cancellationToken);

        public void CreateUserProfile(UserProfile profile) => _dbContext.UserProfiles.Add(profile);

        public void UpdateUserProfile(UserProfile profile) => _dbContext.UserProfiles.Update(profile);

        public void DeleteUserProfile(UserProfile profile) => _dbContext.UserProfiles.Remove(profile);

    }
}
