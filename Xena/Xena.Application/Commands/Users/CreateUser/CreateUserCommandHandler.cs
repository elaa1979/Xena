using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Xena.Application.Abstractions.Repositories;
using Xena.Application.Utils;
using Xena.Domain.Users;
using MediatR;

namespace Xena.Application.Commands.Users.Register
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public CreateUserCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);

            user.Password = HashHelper.GenerateMD5(user.Password);
            await _uow.GetReposiotory<User>().AddAsync(user);
            await _uow.CompleteAsync();

            return Unit.Value;
        }
    }
}