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

namespace Xena.Application.Queries.AmazonServices.GetAdGroups
{
    public class GetAdGroupsQueryHandler : IRequestHandler<GetAdGroupsQuery, List<AdGroupDto>>
    {
        private readonly IAmazonService _amazonService;
        private readonly UserHelper _userHelper;

        public GetAdGroupsQueryHandler(UserHelper userHelper, IAmazonService amazonService)
        {
            _userHelper = userHelper;
            _amazonService = amazonService;
        }

        public async Task<List<AdGroupDto>> Handle(GetAdGroupsQuery request, CancellationToken cancellationToken)
        {
            var userId = _userHelper.GetUserId();
            var result = await _amazonService.GetAdGroupsAsync(userId, request.ProfileId);

            if (result is null)
                throw new BadRequestException(ErrorCodes.CalendarEventsNotExists);

            List<AdGroupDto> events = JsonConvert.DeserializeObject<List<AdGroupDto>>(result);
            return events;
        }
    }
}