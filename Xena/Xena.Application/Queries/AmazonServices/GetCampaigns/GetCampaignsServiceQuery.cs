using MediatR;
using System.Collections.Generic;

namespace Xena.Application.Queries.AmazonServices.GetCampaigns
{
    public class GetCampaignsServiceQuery : IRequest<List<CampaignDto>>
    {
        public long ProfileId { get; set; }
        public bool SyncDB { get; set; }
    }
}