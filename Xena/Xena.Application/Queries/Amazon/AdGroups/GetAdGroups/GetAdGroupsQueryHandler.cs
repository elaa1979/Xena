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

namespace Xena.Application.Queries.Amazon.AdGroups.GetAdGroups
{
    public class GetAdGroupsQueryHandler : IRequestHandler<GetAdGroupsQuery, List<AdGroupDto>>
    {
        private readonly IAmazonService _amazonService;
        private readonly UserHelper _userHelper;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetAdGroupsQueryHandler(IUnitOfWork uow, IMapper mapper, UserHelper userHelper, IAmazonService amazonService)
        {
            _uow = uow;
            _mapper = mapper;
            _userHelper = userHelper;
            _amazonService = amazonService;
        }

        public async Task<List<AdGroupDto>> Handle(GetAdGroupsQuery request, CancellationToken cancellationToken)
        {
            List<AdGroupDto> results;
            var userId = _userHelper.GetUserId();
            if (request.Nocache)
            {
                var result = await _amazonService.GetAdGroupsAsync(userId, request.ProfileId);

                if (result is null)
                    throw new BadRequestException(ErrorCodes.CalendarEventsNotExists);

                results = JsonConvert.DeserializeObject<List<AdGroupDto>>(result);
                foreach (AdGroupDto item in results)
                {
                    var currAdGroup = await _uow.GetReposiotory<AmazonAdGroup>().GetAsync(item.adGroupId);
                    if (currAdGroup is null)
                    {
                        currAdGroup = _mapper.Map<AmazonAdGroup>(item);
                        currAdGroup.profileId = request.ProfileId;
                        currAdGroup.UserId = _userHelper.GetUserId();
                        await _uow.GetReposiotory<AmazonAdGroup>().AddAsync(currAdGroup);
                    }
                    else
                    {
                        if (_userHelper.GetUserId() != currAdGroup.UserId)
                            throw new ForbiddenException(ErrorCodes.Forbidden);

                        currAdGroup = _mapper.Map(item, currAdGroup);
                        currAdGroup.profileId = request.ProfileId;
                        currAdGroup.UserId = _userHelper.GetUserId();
                    }
                    await _uow.CompleteAsync();
                }
            }
            else
            {
                var adGroups = await _uow.GetReposiotory<AmazonAdGroup>().GetListAsync(x => x.UserId == userId);
                results = _mapper.Map<List<AdGroupDto>>(adGroups.ToList());
                results = adGroups.ToList().ConvertAll(x =>
                {
                    AdGroupDto adGroupDto = System.Text.Json.JsonSerializer.Deserialize<AdGroupDto>(x.Data, null);
                    adGroupDto.profileId = request.ProfileId;
                    return adGroupDto;
                });
            }
            return results;
        }
    }
}