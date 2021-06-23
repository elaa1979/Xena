using System;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using Xena.Application.Abstractions.Repositories;
using Xena.Application.Common.Exceptions;
using Xena.Application.Utils;
using Xena.Domain.Users;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Xena.Application.Commands.Users.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Token>
    {
        private readonly IUnitOfWork _uow;
        private readonly TokenService _tokenService;
        public LoginCommandHandler(IUnitOfWork uow, TokenService tokenService)
        {
            _uow = uow;
            _tokenService = tokenService;
        }

        public async Task<Token> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _uow.GetReposiotory<User>().GetByAsync(x => x.Email == request.Email);

            if (user is null || user.Password != HashHelper.GenerateMD5(request.Password))
                throw new AuthenticationException(ErrorCodes.IncorrectCredentials);

            return _tokenService.CreateToken(user.Id);
        }
    }
}