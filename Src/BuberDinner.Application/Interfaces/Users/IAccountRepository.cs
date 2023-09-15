using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Interfaces.Users
{
    public interface IAccountRepository : IRepositoryBase<Account>
    // public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAllAccountsByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);

        Task<Account?> GetAccountByIdAsync(Guid accountId, CancellationToken cancellationToken = default);

        void CreateAccount(Account account);

        void UpdateAccount(Account account);

        void DeleteAccount(Account account);
    }
}
