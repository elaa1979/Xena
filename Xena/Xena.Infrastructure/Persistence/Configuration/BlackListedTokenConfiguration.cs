using Xena.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Xena.Infrastructure.Persistence.Configuration
{
    public class BlackListedTokenConfiguration : IEntityTypeConfiguration<BlackListedToken>
    {
        public void Configure(EntityTypeBuilder<BlackListedToken> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Token)
                .HasMaxLength(255);
        }
    }
}