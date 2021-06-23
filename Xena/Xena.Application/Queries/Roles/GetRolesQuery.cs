using System.Collections.Generic;
using Xena.Application.Common.Models;
using MediatR;

namespace Xena.Application.Queries.Roles
{
    public class GetRolesQuery:BaseRequest, IRequest<BaseResult<RoleDto>>
    {
        
    }
}