using System.Threading.Tasks;
using Xena.Application.Queries.Roles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Xena.Api.Controllers
{
    public class RolesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetRolesQuery request)
        => Ok(await Mediator.Send(request));
    }
}