using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xena.Domain.AmazonServices
{
    public class Keyword
    {
        public long keywordId { get; set; }
        public long adGroupId { get; set; }
        public long campaignId { get; set; }
        public string keywordText { get; set; }
        public string matchType { get; set; }
        public string state { get; set; }
        public double bid { get; set; }
    }
}
