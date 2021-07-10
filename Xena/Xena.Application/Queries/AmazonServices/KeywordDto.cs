using System;
using System.Collections.Generic;
using Xena.Application.Common.Models;
using Newtonsoft.Json;

namespace Xena.Application.Queries.AmazonServices
{
    public class KeywordDto
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


