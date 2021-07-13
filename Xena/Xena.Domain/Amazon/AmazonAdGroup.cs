using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xena.Domain.Amazon
{
    public class AmazonAdGroup : AmazonEntity
    {
        public long profileId { get; set; }
        public long campaignId { get; set; }
    }
}
