using System;
using System.Collections.Generic;
using Xena.Application.Common.Models;
using Newtonsoft.Json;

namespace Xena.Application.Queries.AmazonServices
{
    public class AdGroupDto
    {
        public long adGroupId { get; set; }
        public string name { get; set; }
        public long campaignId { get; set; }
        public double defaultBid { get; set; }
        public string state { get; set; }
    }
}


