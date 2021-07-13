using System.Net;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Xena.Api.Controllers.Amazon
{
    [ApiController]
    [Route("Amazon/[controller]")]
    [Authorize]
    [Produces("application/json")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public class AmazonBaseController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}