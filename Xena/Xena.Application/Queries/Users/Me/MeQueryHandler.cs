using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Xena.Application.Abstractions.Repositories;
using Xena.Application.Utils;
using Xena.Domain.Users;
using MediatR;

namespace Xena.Application.Queries.Users.Me
{
    public class MeQueryHandler : IRequestHandler<MeQuery, UserDto>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly UserHelper _userHelper;

        public MeQueryHandler(IUnitOfWork uow, IMapper mapper, UserHelper userHelper)
        {
            _uow = uow;
            _mapper = mapper;
            _userHelper = userHelper;
        }
        public async Task<UserDto> Handle(MeQuery request, CancellationToken cancellationToken)
        {
            var user = await _uow.GetReposiotory<User>().GetAsync(_userHelper.GetUserId());
            return _mapper.Map<UserDto>(user);
        }
    }
}
