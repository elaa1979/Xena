using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xena.Application.Common.Exceptions;
using Xena.Application.Commands.Amazon.Profiles.CreateProfile;
using Xena.Application.Commands.Amazon.Profiles.UpdateProfile;
using Xena.Application.Commands.Amazon.Profiles.DeleteProfile;
using Xena.Application.Queries.Amazon.Profiles.GetProfiles;
using Xena.Application.Queries.Amazon.Profiles.GetProfile;
using Xena.Application.Queries.AmazonServices.GetProfiles;

namespace Xena.Api.Controllers.Amazon
{
    public class ProfilesController : AmazonBaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateProfileCommand request)
        => Ok(await Mediator.Send(request));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProfileCommand request)
        {
            if (id != request.profileId)
                throw new BadRequestException(ErrorCodes.InvalidParameters);

            return Ok(await Mediator.Send(request));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        => Ok(await Mediator.Send(new DeleteProfileCommand { Id = id }));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        => Ok(await Mediator.Send(new GetProfileQuery {  Id = id }));

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetProfilesQuery request)
        => Ok(await Mediator.Send(request));

    }
}
