using System;
using MediatR;

namespace Xena.Application.Queries.Users.Me
{
    public class MeQuery : IRequest<UserDto>
    {
    }
}
