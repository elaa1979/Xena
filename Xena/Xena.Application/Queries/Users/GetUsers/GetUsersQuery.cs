using System;
using Xena.Application.Common.Models;
using MediatR;

namespace Xena.Application.Queries.Users.GetUsers
{
    public class GetUsersQuery : BaseRequest, IRequest<BaseResult<UserDto>>
    {
        
    }
}
