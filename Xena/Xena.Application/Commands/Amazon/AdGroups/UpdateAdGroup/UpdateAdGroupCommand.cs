using System;
using MediatR;

namespace Xena.Application.Commands.Amazon.AdGroups.UpdateAdGroup
{
    public class UpdateAdGroupCommand : IRequest
    {
        public long adGroupId { get; set; }
        public long profileId { get; set; }
        public string name { get; set; }
        public long campaignId { get; set; }
        public double defaultBid { get; set; }
        public string state { get; set; }
    }
}

