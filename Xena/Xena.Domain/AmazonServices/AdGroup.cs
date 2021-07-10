using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xena.Domain.AmazonServices
{
    public class AdGroup
    {
        public long adGroupId { get; set; }
        public string name { get; set; }
        public long campaignId { get; set; }
        public double defaultBid { get; set; }
        public string state { get; set; }
    }
}
