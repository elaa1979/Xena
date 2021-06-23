using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Xena.Application.Abstractions.Repositories;
using Xena.Application.Common.Models;
using Xena.Domain.Users;
using MediatR;

namespace Xena.Application.Queries.Users.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, BaseResult<UserDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public GetUsersQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<BaseResult<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _uow.GetReposiotory<User>().GetPagingListAsync((BaseRequest)request);
            return _mapper.Map<BaseResult<UserDto>>(users);
        }
    }
}
