using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Xena.Application.Abstractions.Repositories;
using Xena.Application.Common.Exceptions;
using Xena.Application.Utils;
using Xena.Domain.Amazon;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Xena.Application.Commands.Amazon.AdGroups.UpdateAdGroup
{
    public class UpdateAdGroupCommandHandler : IRequestHandler<UpdateAdGroupCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly UserHelper _userHelper;
        public UpdateAdGroupCommandHandler(IUnitOfWork uow, IMapper mapper, UserHelper userHelper)
        {
            _uow = uow;
            _mapper = mapper;
            _userHelper = userHelper;
        }
        public async Task<Unit> Handle(UpdateAdGroupCommand request, CancellationToken cancellationToken)
        {
            var adGroup = await _uow.GetReposiotory<AmazonAdGroup>().GetAsync(request.adGroupId);

            if (adGroup is null)
                throw new BadRequestException(ErrorCodes.UserNotExists);

            if (_userHelper.GetUserId() != adGroup.UserId)
                throw new ForbiddenException(ErrorCodes.Forbidden);

            adGroup = _mapper.Map<UpdateAdGroupCommand, AmazonAdGroup>(request, adGroup);
            await _uow.CompleteAsync();

            return Unit.Value;
        }
    }
}