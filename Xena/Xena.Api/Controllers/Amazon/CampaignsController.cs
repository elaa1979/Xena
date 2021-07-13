using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xena.Application.Commands.Amazon.Campaigns.CreateCampaign;
using Xena.Application.Commands.Amazon.Campaigns.DeleteCampaign;
using Xena.Application.Commands.Amazon.Campaigns.UpdateCampaign;
using Xena.Application.Common.Exceptions;
using Xena.Application.Queries.Amazon.Campaigns.GetCampaign;
using Xena.Application.Queries.Amazon.Campaigns.GetCampaigns;
using Xena.Application.Queries.AmazonServices.GetCampaigns;

namespace Xena.Api.Controllers.Amazon
{
    public class CampaignsController : AmazonBaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateCampaignCommand request)
        => Ok(await Mediator.Send(request));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCampaignCommand request)
        {
            if (id != request.campaignId)
                throw new BadRequestException(ErrorCodes.InvalidParameters);

            return Ok(await Mediator.Send(request));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        => Ok(await Mediator.Send(new DeleteCampaignCommand { Id = id }));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        => Ok(await Mediator.Send(new GetCampaignQuery { Id = id }));

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetCampaignsQuery request)
        => Ok(await Mediator.Send(request));
    }
}
