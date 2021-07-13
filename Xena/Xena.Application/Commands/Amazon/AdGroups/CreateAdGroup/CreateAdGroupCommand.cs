using System;
using MediatR;

namespace Xena.Application.Commands.Amazon.AdGroups.CreateAdGroup
{
    public class CreateAdGroupCommand : IRequest
    {
        public long adGroupId { get; set; }
        public long profileId { get; set; }
        public string name { get; set; }
        public long campaignId { get; set; }
        public double defaultBid { get; set; }
        public string state { get; set; }
    }
}

