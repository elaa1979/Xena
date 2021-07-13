using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xena.Application.Common.Exceptions;
using Xena.Application.Commands.Amazon.AdGroups.CreateAdGroup;
using Xena.Application.Commands.Amazon.AdGroups.UpdateAdGroup;
using Xena.Application.Commands.Amazon.AdGroups.DeleteAdGroup;
using Xena.Application.Queries.Amazon.AdGroups.GetAdGroup;
using Xena.Application.Queries.Amazon.AdGroups.GetAdGroups;
using Xena.Application.Queries.AmazonServices.GetAdGroups;

namespace Xena.Api.Controllers.Amazon
{
    public class AdGroupsController : AmazonBaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateAdGroupCommand request)
        => Ok(await Mediator.Send(request));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateAdGroupCommand request)
        {
            if (id != request.adGroupId)
                throw new BadRequestException(ErrorCodes.InvalidParameters);

            return Ok(await Mediator.Send(request));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        => Ok(await Mediator.Send(new DeleteAdGroupCommand { Id = id }));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        => Ok(await Mediator.Send(new GetAdGroupQuery { Id = id }));

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetAdGroupsQuery request)
        => Ok(await Mediator.Send(request));
    }
}
