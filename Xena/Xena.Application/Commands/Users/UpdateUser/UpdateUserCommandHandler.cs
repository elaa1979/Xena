using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Xena.Application.Abstractions.Repositories;
using Xena.Application.Common.Exceptions;
using Xena.Application.Utils;
using Xena.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Xena.Application.Commands.Users.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly UserHelper _userHelper;
        public UpdateUserCommandHandler(IUnitOfWork uow, IMapper mapper, UserHelper userHelper)
        {
            _uow = uow;
            _mapper = mapper;
            _userHelper = userHelper;
        }
        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var currUser = await _uow.GetReposiotory<User>().GetAsync(request.Id);

            if (currUser is null)
                throw new BadRequestException(ErrorCodes.UserNotExists);

            if (_userHelper.GetUserId() != currUser.Id)
                throw new ForbiddenException(ErrorCodes.Forbidden);

            currUser = _mapper.Map<UpdateUserCommand, User>(request, currUser);
            await _uow.CompleteAsync();

            return Unit.Value;
        }
    }
}