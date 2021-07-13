using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Xena.Domain.Amazon;

namespace Xena.Infrastructure.Persistence.Configuration
{
    public class AmazonProfileConfiguration : IEntityTypeConfiguration<AmazonProfile>
    {
        public void Configure(EntityTypeBuilder<AmazonProfile> builder)
        {
            builder
                .HasKey(x => x.Id);
        }
    }
}