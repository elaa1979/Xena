using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Xena.Application.Abstractions.Repositories;
using Xena.Application.Common.Models;
using Xena.Domain.Roles;
using MediatR;

namespace Xena.Application.Queries.Roles
{
    public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, BaseResult<RoleDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public GetRolesQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<BaseResult<RoleDto>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _uow.GetReposiotory<Role>().GetPagingListAsync((BaseRequest)request,true);
            return _mapper.Map<BaseResult<RoleDto>>(roles);
        }
    }
}