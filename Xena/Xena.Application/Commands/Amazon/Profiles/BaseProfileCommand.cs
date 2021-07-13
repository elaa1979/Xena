using System;
using MediatR;

namespace Xena.Application.Commands.Amazon.Profiles
{
    public class BaseProfileCommand : IRequest
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