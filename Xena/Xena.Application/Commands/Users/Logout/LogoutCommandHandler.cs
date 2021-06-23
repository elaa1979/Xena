using System.Threading;
using System.Threading.Tasks;
using Xena.Application.Abstractions.Repositories;
using Xena.Application.Utils;
using MediatR;

namespace Xena.Application.Commands.Users.Logout
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly TokenService _tokenService;
        public LogoutCommandHandler(IUnitOfWork uow, TokenService tokenService)
        {
            _uow = uow;
            _tokenService = tokenService;
        }

        public async Task<Unit> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            await _tokenService.AddToBlackList();
            return Unit.Value;
        }
    }
}