using System.Threading.Tasks;
using Xena.Application.Queries.AmazonServices.GetProfiles;
using Xena.Application.Queries.AmazonServices.GetAdGroups;
using Xena.Application.Queries.AmazonServices.GetCampaigns;
using Xena.Application.Queries.AmazonServices.GetKeywords;
using Microsoft.AspNetCore.Mvc;

namespace Xena.Api.Controllers
{
    public class AmazonServicesController : BaseController
    {
        [HttpGet("GetProfiles")]
        public async Task<IActionResult> GetProfiles([FromQuery] GetProfilesQuery request)
        => Ok(await Mediator.Send(request));

        [HttpGet("GetAdGroups")]
        public async Task<IActionResult> GetAdGroups([FromQuery] GetAdGroupsQuery request)
        => Ok(await Mediator.Send(request));

        [HttpGet("GetCampaigns")]
        public async Task<IActionResult> GetCampaigns([FromQuery] GetCampaignsQuery request)
        => Ok(await Mediator.Send(request));

        [HttpGet("GetKeywords")]
        public async Task<IActionResult> GetKeywords([FromQuery] GetKeywordsQuery request)
        => Ok(await Mediator.Send(request));

    }
}
