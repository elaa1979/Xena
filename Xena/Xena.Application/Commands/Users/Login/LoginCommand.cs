using Xena.Application.Utils;
using MediatR;

namespace Xena.Application.Commands.Users.Login
{
    public class LoginCommand:IRequest<Token>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}