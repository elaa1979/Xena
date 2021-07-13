using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Xena.Application.Commands.Amazon.Campaigns
{
    public class BaseCampaignCommand: IRequest
    {
        public long campaignId { get; set; }
        public long profileId { get; set; }
        public string name { get; set; }
        public string campaignType { get; set; }
        public string targetingType { get; set; }
        public bool premiumBidAdjustment { get; set; }
        public double dailyBudget { get; set; }
        public string startDate { get; set; }
        public string state { get; set; }
        public Bidding bidding { get; set; }
    }

    public class Bidding
    {
        public string strategy { get; set; }
        public List<object> adjustments { get; set; }
    }
}
