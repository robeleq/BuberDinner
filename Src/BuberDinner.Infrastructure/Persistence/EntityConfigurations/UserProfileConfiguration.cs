using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BuberDinner.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BuberDinner.Infrastructure.Persistence.EntityConfigurations
{
    internal sealed class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.ToTable(nameof(UserProfile));

            builder.HasKey(profile => profile.Id);

            builder.Property(account => account.Id).ValueGeneratedOnAdd();

            builder.Property(profile => profile.FirstName).HasMaxLength(15);

            builder.Property(profile => profile.LastName).HasMaxLength(15);

            builder.Property(profile => profile.PhoneNumber).IsRequired();

            builder.HasOne(profile => profile.User);
        }
    }
}
