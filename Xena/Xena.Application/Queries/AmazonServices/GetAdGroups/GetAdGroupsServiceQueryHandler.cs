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
    public class GetAdGroupsServiceQueryHandler : IRequestHandler<GetAdGroupsServiceQuery, List<AdGroupDto>>
    {
        private readonly IAmazonService _amazonService;
        private readonly UserHelper _userHelper;
        private IMediator _mediator;
        public GetAdGroupsServiceQueryHandler(UserHelper userHelper, IAmazonService amazonService, IMediator mediator)
        {
            _userHelper = userHelper;
            _amazonService = amazonService;
            _mediator = mediator;
            

        }

        public async Task<List<AdGroupDto>> Handle(GetAdGroupsServiceQuery request, CancellationToken cancellationToken)
        {
            var userId = _userHelper.GetUserId();
            var result = await _amazonService.GetAdGroupsAsync(userId, request.ProfileId);

            if (result is null)
                throw new BadRequestException(ErrorCodes.CalendarEventsNotExists);

            List<AdGroupDto> adGroups = JsonConvert.DeserializeObject<List<AdGroupDto>>(result);
            if(request.SyncDB && adGroups != null)
            {
                foreach(AdGroupDto adGroup in adGroups)
                {
                }
            }
            return adGroups;
        }
    }
}