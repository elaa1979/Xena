using Xena.Domain.Amazon;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Xena.Infrastructure.Persistence.Configuration
{
    public class AmazonKeywordConfiguration : IEntityTypeConfiguration<AmazonKeyword>
    {
        public void Configure(EntityTypeBuilder<AmazonKeyword> builder)
        {
            builder
                .HasKey(x => x.Id);
        }
    }
}