using MediatR;

namespace Xena.Application.Commands.Amazon.Campaigns.DeleteCampaign
{
    public class DeleteCampaignCommand: IRequest
    {
        public long Id { get; set; }
    }
}