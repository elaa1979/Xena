using MediatR;
using System.Collections.Generic;

namespace Xena.Application.Queries.Amazon.Campaigns.GetCampaigns
{
    public class GetCampaignsQuery : IRequest<List<CampaignDto>>
    {
        public long ProfileId { get; set; }
        public bool Nocache { get; set; }
    }
}