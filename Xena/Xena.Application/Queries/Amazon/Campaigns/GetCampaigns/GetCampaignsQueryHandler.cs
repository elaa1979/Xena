using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xena.Application.Abstractions.AmazonServices;
using Xena.Application.Abstractions.Repositories;
using Xena.Application.Common.Exceptions;
using MediatR;
using AutoMapper;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Caching.Memory;
using Xena.Application.Utils;
using Xena.Domain.Amazon;
using Xena.Application.Common.Models;
using MediatR;

namespace Xena.Application.Queries.Amazon.Campaigns.GetCampaigns
{
    public class GetCampaignsQueryHandler : IRequestHandler<GetCampaignsQuery, List<CampaignDto>>
    {
        private readonly IAmazonService _amazonService;
        private readonly UserHelper _userHelper;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetCampaignsQueryHandler(IUnitOfWork uow, IMapper mapper, UserHelper userHelper, IAmazonService amazonService)
        {
            _uow = uow;
            _mapper = mapper;
            _userHelper = userHelper;
            _amazonService = amazonService;
        }

        public async Task<List<CampaignDto>> Handle(GetCampaignsQuery request, CancellationToken cancellationToken)
        {
            List<CampaignDto> results;
            var userId = _userHelper.GetUserId();
            if (request.Nocache)
            {
                var result = await _amazonService.GetCampaignsAsync(userId, request.ProfileId);

                if (result is null)
                    throw new BadRequestException(ErrorCodes.CalendarEventsNotExists);

                results = JsonConvert.DeserializeObject<List<CampaignDto>>(result);
                foreach (CampaignDto item in results)
                {
                    var currCampaign = await _uow.GetReposiotory<AmazonCampaign>().GetAsync(item.campaignId);
                    if (currCampaign is null)
                    {
                        currCampaign = _mapper.Map<AmazonCampaign>(item);
                        currCampaign.profileId = request.ProfileId;
                        currCampaign.UserId = _userHelper.GetUserId();
                        await _uow.GetReposiotory<AmazonCampaign>().AddAsync(currCampaign);
                    }
                    else
                    {
                        if (_userHelper.GetUserId() != currCampaign.UserId)
                            throw new ForbiddenException(ErrorCodes.Forbidden);

                        currCampaign = _mapper.Map(item, currCampaign);
                        currCampaign.profileId = request.ProfileId;
                        currCampaign.UserId = _userHelper.GetUserId();

                    }
                    await _uow.CompleteAsync();
                }
            }
            else
            {
                var campaigns = await _uow.GetReposiotory<AmazonCampaign>().GetListAsync(x => x.UserId == userId);
                results = campaigns.ToList().ConvertAll(x =>
                {
                    CampaignDto campaignDto = System.Text.Json.JsonSerializer.Deserialize<CampaignDto>(x.Data, null);
                    campaignDto.profileId = request.ProfileId;
                    return campaignDto;
                });
            }
            return results;
        }
    }
}