using MediatR;
using System.Collections.Generic;

namespace Xena.Application.Queries.Amazon.Campaigns.GetCampaign
{
    public class GetCampaignQuery : IRequest<CampaignDto>
    {
        public long Id { get; set; }
    }
}