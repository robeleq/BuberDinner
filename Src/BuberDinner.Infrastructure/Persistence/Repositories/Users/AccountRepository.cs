using BuberDinner.Application.Interfaces.Users;
using BuberDinner.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BuberDinner.Infrastructure.Persistence.Repositories.Users
{
    internal sealed class AccountRepository : RepositoryBase<Account>, IAccountRepository
    // internal sealed class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AccountRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }
        //public AccountRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;

        public async Task<IEnumerable<Account>> GetAllAccountsByUserIdAsync(Guid userId, CancellationToken cancellationToken = default) =>
            await _dbContext.Accounts.Where(x => x.AppUserId == userId).ToListAsync(cancellationToken);

        public async Task<Account?> GetAccountByIdAsync(Guid accountId, CancellationToken cancellationToken = default) =>
            await _dbContext.Accounts.FirstOrDefaultAsync(x => x.Id == accountId, cancellationToken);

        public void CreateAccount(Account account) => _dbContext.Accounts.Add(account);

        public void UpdateAccount(Account account) => _dbContext.Accounts.Update(account);

        public void DeleteAccount(Account account) => _dbContext.Accounts.Remove(account);
    }
}
