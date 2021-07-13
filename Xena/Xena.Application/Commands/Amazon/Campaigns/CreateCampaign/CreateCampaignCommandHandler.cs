using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Xena.Application.Abstractions.Repositories;
using Xena.Application.Utils;
using Xena.Domain.Amazon;
using MediatR;

namespace Xena.Application.Commands.Amazon.Campaigns.CreateCampaign
{
    public class CreateCampaignCommandHandler : IRequestHandler<CreateCampaignCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly UserHelper _userHelper;
        public CreateCampaignCommandHandler(IUnitOfWork uow, IMapper mapper, UserHelper userHelper)
        {
            _uow = uow;
            _mapper = mapper;
            _userHelper = userHelper;
        }
        public async Task<Unit> Handle(CreateCampaignCommand request, CancellationToken cancellationToken)
        {
            var campaign = _mapper.Map<AmazonCampaign>(request);
            campaign.UserId = _userHelper.GetUserId();
            await _uow.GetReposiotory<AmazonCampaign>().AddAsync(campaign);
            await _uow.CompleteAsync();

            return Unit.Value;
        }
    }
}