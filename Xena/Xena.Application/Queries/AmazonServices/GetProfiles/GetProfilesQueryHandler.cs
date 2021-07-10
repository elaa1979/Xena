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

namespace Xena.Application.Queries.AmazonServices.GetProfiles
{
    public class GetProfilesQueryHandler : IRequestHandler<GetProfilesQuery, List<ProfileDto>>
    {
        private readonly IAmazonService _amazonService;
        private readonly UserHelper _userHelper;

        public GetProfilesQueryHandler(UserHelper userHelper, IAmazonService amazonService)
        {
            _userHelper = userHelper;
            _amazonService = amazonService;
        }

        public async Task<List<ProfileDto>> Handle(GetProfilesQuery request, CancellationToken cancellationToken)
        {
            var userId = _userHelper.GetUserId();
            var result = await _amazonService.GetProfilesAsync(userId);

            if (result is null)
                throw new BadRequestException(ErrorCodes.CalendarEventsNotExists);

            List<ProfileDto> events = JsonConvert.DeserializeObject<List<ProfileDto>>(result);
            return events;
        }
    }
}