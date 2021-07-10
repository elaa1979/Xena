using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xena.Domain.AmazonServices
{
    public class Profile
    {
        public long profileId { get; set; }
        public string countryCode { get; set; }
        public string currencyCode { get; set; }
        public decimal dailyBudget { get; set; }
        public string timezone { get; set; }
        public AccountInfo accountInfo { get; set; }
    }

    public class AccountInfo
    {
        public string marketplaceStringId { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public bool validPaymentMethod { get; set; }
    }
}
