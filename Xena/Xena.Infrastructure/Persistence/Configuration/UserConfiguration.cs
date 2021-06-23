using Xena.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Xena.Infrastructure.Persistence.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .UseIdentityColumn();

            builder
                .HasIndex(x => x.Email)
                .IsUnique();

            builder
                .Property(x => x.FirstName)
                .HasMaxLength(255);

            builder
                .Property(x => x.LastName)
                .HasMaxLength(255);

            builder
                .Property(x => x.Email)
                .HasMaxLength(255);

            builder
                .Property(x => x.Password)
                .HasMaxLength(255);

            builder
                .Property(x => x.Photo)
                .HasMaxLength(255);

            builder
                .Property(x => x.Caption)
                .HasMaxLength(255);

            builder
                .Property(x => x.Address)
                .HasMaxLength(255);

            builder
                .HasQueryFilter(x => !x.IsDeleted);

        }
    }
}