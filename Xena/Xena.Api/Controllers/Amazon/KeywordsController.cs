using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xena.Application.Common.Exceptions;
using Xena.Application.Commands.Amazon.Keywords.CreateKeyword;
using Xena.Application.Commands.Amazon.Keywords.UpdateKeyword;
using Xena.Application.Commands.Amazon.Keywords.DeleteKeyword;
using Xena.Application.Queries.Amazon.Keywords.GetKeywords;
using Xena.Application.Queries.AmazonServices.GetKeywords;

namespace Xena.Api.Controllers.Amazon
{
    public class KeywordsController : AmazonBaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateKeywordCommand request)
        => Ok(await Mediator.Send(request));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateKeywordCommand request)
        {
            if (id != request.keywordId)
                throw new BadRequestException(ErrorCodes.InvalidParameters);

            return Ok(await Mediator.Send(request));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        => Ok(await Mediator.Send(new DeleteKeywordCommand { Id = id }));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        => Ok(await Mediator.Send(new GetKeywordsQuery { ProfileId = id }));

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetKeywordsQuery request)
        => Ok(await Mediator.Send(request));

    }
}
