using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Infrastructure.Persistence.EntityConfigurations
{
    internal sealed class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable(nameof(AppUser));

            builder.HasKey(appUser => appUser.Id);

            builder.Property(account => account.Id).ValueGeneratedOnAdd();

            builder.Property(appUser => appUser.FirstName).HasMaxLength(15);

            builder.Property(appUser => appUser.LastName).HasMaxLength(15);

            builder.Property(appUser => appUser.Email).IsRequired();

            builder.HasMany(appUser => appUser.Accounts)
                .WithOne()
                .HasForeignKey(account => account.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
