using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Xena.Application.Abstractions.Repositories;
using Xena.Application.Common.Exceptions;
using Xena.Application.Utils;
using Xena.Domain.Amazon;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Xena.Application.Commands.Amazon.Campaigns.UpdateCampaign
{
    public class UpdateCampaignCommandHandler : IRequestHandler<UpdateCampaignCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly UserHelper _userHelper;
        public UpdateCampaignCommandHandler(IUnitOfWork uow, IMapper mapper, UserHelper userHelper)
        {
            _uow = uow;
            _mapper = mapper;
            _userHelper = userHelper;
        }
        public async Task<Unit> Handle(UpdateCampaignCommand request, CancellationToken cancellationToken)
        {
            var campaign = await _uow.GetReposiotory<AmazonCampaign>().GetAsync(request.campaignId);

            if (campaign is null)
                throw new BadRequestException(ErrorCodes.UserNotExists);

            if (_userHelper.GetUserId() != campaign.UserId)
                throw new ForbiddenException(ErrorCodes.Forbidden);

            campaign = _mapper.Map(request, campaign);
            await _uow.CompleteAsync();

            return Unit.Value;
        }
    }
}