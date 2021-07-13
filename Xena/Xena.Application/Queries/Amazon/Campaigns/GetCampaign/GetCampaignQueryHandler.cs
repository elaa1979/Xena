using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Xena.Application.Abstractions.Repositories;
using Xena.Application.Common.Exceptions;
using Xena.Application.Utils;
using Xena.Domain.Amazon;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Xena.Application.Queries.Amazon.Campaigns.GetCampaign
{
    public class GetCampaignQueryHandler : IRequestHandler<GetCampaignQuery, CampaignDto>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly UserHelper _userHelper;
        public GetCampaignQueryHandler(IUnitOfWork uow, IMapper mapper, UserHelper userHelper)
        {
            _uow = uow;
            _mapper = mapper;
            _userHelper = userHelper;
        }
        public async Task<CampaignDto> Handle(GetCampaignQuery request, CancellationToken cancellationToken)
        {
            var campaign = await _uow.GetReposiotory<AmazonCampaign>().GetAsync(request.Id);
            return _mapper.Map<CampaignDto>(campaign);
        }
    }
}