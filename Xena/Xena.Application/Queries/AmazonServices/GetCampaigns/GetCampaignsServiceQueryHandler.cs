using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xena.Application.Abstractions.AmazonServices;
using Xena.Application.Common.Exceptions;
using MediatR;
using AutoMapper;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Caching.Memory;
using Xena.Application.Utils;

namespace Xena.Application.Queries.AmazonServices.GetCampaigns
{
    public class GetCampaignsServiceQueryHandler : IRequestHandler<GetCampaignsServiceQuery, List<CampaignDto>>
    {
        private readonly IAmazonService _amazonService;
        private readonly UserHelper _userHelper;

        public GetCampaignsServiceQueryHandler(UserHelper userHelper, IAmazonService amazonService)
        {
            _userHelper = userHelper;
            _amazonService = amazonService;
        }

        public async Task<List<CampaignDto>> Handle(GetCampaignsServiceQuery request, CancellationToken cancellationToken)
        {
            var userId = _userHelper.GetUserId();
            var result = await _amazonService.GetCampaignsAsync(userId, request.ProfileId);

            if (result is null)
                throw new BadRequestException(ErrorCodes.CalendarEventsNotExists);

            List<CampaignDto> events = JsonConvert.DeserializeObject<List<CampaignDto>>(result);
            return events;
        }
    }
}