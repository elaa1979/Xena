using Xena.Domain.Amazon;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Xena.Infrastructure.Persistence.Configuration
{
    public class AmazonCampaignConfiguration : IEntityTypeConfiguration<AmazonCampaign>
    {
        public void Configure(EntityTypeBuilder<AmazonCampaign> builder)
        {
            builder
                .HasKey(x => x.Id);
          
        }
    }
}