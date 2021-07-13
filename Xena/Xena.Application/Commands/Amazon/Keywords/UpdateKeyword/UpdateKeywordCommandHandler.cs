using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Xena.Application.Abstractions.Repositories;
using Xena.Application.Common.Exceptions;
using Xena.Application.Utils;
using Xena.Domain.Amazon;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Xena.Application.Commands.Amazon.Keywords.UpdateKeyword
{
    public class UpdateKeywordCommandHandler : IRequestHandler<UpdateKeywordCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly UserHelper _userHelper;
        public UpdateKeywordCommandHandler(IUnitOfWork uow, IMapper mapper, UserHelper userHelper)
        {
            _uow = uow;
            _mapper = mapper;
            _userHelper = userHelper;
        }
        public async Task<Unit> Handle(UpdateKeywordCommand request, CancellationToken cancellationToken)
        {
            var keyword = await _uow.GetReposiotory<AmazonKeyword>().GetAsync(request.keywordId);

            if (keyword is null)
                throw new BadRequestException(ErrorCodes.UserNotExists);

            if (_userHelper.GetUserId() != keyword.UserId)
                throw new ForbiddenException(ErrorCodes.Forbidden);

            keyword = _mapper.Map<UpdateKeywordCommand, AmazonKeyword>(request, keyword);
            await _uow.CompleteAsync();

            return Unit.Value;
        }
    }
}