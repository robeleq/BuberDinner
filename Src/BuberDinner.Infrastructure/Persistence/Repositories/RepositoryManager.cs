using BuberDinner.Application.Interfaces.Users;
using BuberDinner.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuberDinner.Infrastructure.Persistence.Repositories.Users;
using BuberDinner.Infrastructure.Data.Repositories.Users;

namespace BuberDinner.Infrastructure.Persistence.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly ApplicationDbContext _dbContext;

        //  Repository instances are only going to be created when we access them for the first time,
        //  and not before that.
        private readonly Lazy<IUserRepository> _userRepository;

        private readonly Lazy<IAccountRepository> _accountRepository;

        private readonly Lazy<IUserProfileRepository> _userProfileRepository;

        public RepositoryManager(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(_dbContext));

            _accountRepository = new Lazy<IAccountRepository>(() => new AccountRepository(_dbContext));

            _userProfileRepository = new Lazy<IUserProfileRepository>(() => new UserProfileRepository(_dbContext));
        }

        public IUserRepository UserRepository => _userRepository.Value;

        public IAccountRepository AccountRepository => _accountRepository.Value;

        public IUserProfileRepository UserProfileRepository => _userProfileRepository.Value;

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default) => await _dbContext.SaveChangesAsync(cancellationToken);

    }
}
