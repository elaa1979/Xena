using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xena.Domain.AmazonServices
{
    public class AmazonConfig
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string RedirectUri { get; set; }
        public string AccessTokenUrl { get; set; }
        public string ProfileUrl { get; set; }
        public string AdGroupUrl { get; set; }
        public string CampaignUrl { get; set; }
        public string KeywordsUrl { get; set; }
    }
}
