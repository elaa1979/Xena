using Xena.Domain.Amazon;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Xena.Infrastructure.Persistence.Configuration
{
    public class AmazonAdGroupConfiguration : IEntityTypeConfiguration<AmazonAdGroup>
    {
        public void Configure(EntityTypeBuilder<AmazonAdGroup> builder)
        {
            builder
                .HasKey(x => x.Id);
        }
    }
}