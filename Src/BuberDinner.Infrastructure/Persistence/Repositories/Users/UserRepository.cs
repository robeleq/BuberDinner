using BuberDinner.Application.Interfaces.Users;
using BuberDinner.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BuberDinner.Infrastructure.Persistence.Repositories.Users
{
    internal sealed class UserRepository : RepositoryBase<AppUser>, IUserRepository
    // internal sealed class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
           : base(dbContext)
        {
            _dbContext = dbContext;
        }
        /*
        // public UserRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;

        public async Task<IEnumerable<AppUser>> GetAllUsersAsync(CancellationToken cancellationToken = default) =>
            await _dbContext.Users.Include(x => x.Accounts).ToListAsync(cancellationToken);

        public async Task<AppUser?> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken = default) =>
            await _dbContext.Users.Include(x => x.Accounts).FirstOrDefaultAsync(x => x.Id == userId, cancellationToken);

        public async Task<AppUser?> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default) =>
            await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);

        public void CreateUser(AppUser user) => _dbContext.Users.Add(user);

        public void UpdateUser(AppUser user) => _dbContext.Users.Update(user);

        public void DeleteUser(AppUser user) => _dbContext.Users.Remove(user); */

        public void CreateUser(AppUser user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(AppUser user)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AppUser>> GetAllUsersAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<AppUser?> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<AppUser?> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(AppUser user)
        {
            throw new NotImplementedException();
        }
    }
}
