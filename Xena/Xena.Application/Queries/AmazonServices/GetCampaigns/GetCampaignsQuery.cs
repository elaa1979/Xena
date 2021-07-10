using MediatR;
using System.Collections.Generic;

namespace Xena.Application.Queries.AmazonServices.GetCampaigns
{
    public class GetCampaignsQuery : IRequest<List<CampaignDto>>
    {
        public long ProfileId { get; set; }
    }
}