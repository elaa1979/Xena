using System.Net;
using System.Threading.Tasks;
using Xena.Application.Commands.Users.Login;
using Xena.Application.Commands.Users.Logout;
using Xena.Application.Commands.Users.Register;
using Xena.Application.Commands.Users.UpdateUser;
using Xena.Application.Common.Exceptions;
using Xena.Application.Queries.Users;
using Xena.Application.Queries.Users.GetUser;
using Xena.Application.Queries.Users.GetUsers;
using Xena.Application.Queries.Users.Me;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Xena.Api.Controllers
{
    public class UsersController : BaseController
    {
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginCommand request)
           => Ok(await Mediator.Send(request));

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(CreateUserCommand request)
        => Ok(await Mediator.Send(request));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUserCommand request)
        {
            if (id != request.Id)
                throw new BadRequestException(ErrorCodes.InvalidParameters);

            return Ok(await Mediator.Send(request));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        => Ok(await Mediator.Send(new GetUserQuery { Id = id }));

        [HttpGet("Me")]
        public async Task<IActionResult> Me()
        => Ok(await Mediator.Send(new MeQuery { }));

        [HttpPost("Logout")]
        public async Task<IActionResult> LogOut(LogoutCommand request)
           => Ok(await Mediator.Send(request));

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetUsersQuery request)
        => Ok(await Mediator.Send(request));

    }
}