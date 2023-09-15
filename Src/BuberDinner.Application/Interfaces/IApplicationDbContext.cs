using BuberDinner.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BuberDinner.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<AppUser> AppUsers { get; set; }
        
        public DbSet<Account> Accounts { get; set; }

        public DbSet<UserProfile> UserProfiles { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
