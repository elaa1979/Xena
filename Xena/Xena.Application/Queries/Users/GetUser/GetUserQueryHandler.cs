using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Xena.Application.Abstractions.Repositories;
using Xena.Application.Common.Exceptions;
using Xena.Application.Utils;
using Xena.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Xena.Application.Queries.Users.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly UserHelper _userHelper;
        public GetUserQueryHandler(IUnitOfWork uow, IMapper mapper, UserHelper userHelper)
        {
            _uow = uow;
            _mapper = mapper;
            _userHelper = userHelper;
        }
        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            //if (_userHelper.GetUserId() != request.Id)
            //    throw new ForbiddenException(ErrorCodes.Forbidden);

            var user = await _uow.GetReposiotory<User>().GetAsync(request.Id);
            return _mapper.Map<UserDto>(user);
        }
    }
}