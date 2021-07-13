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

namespace Xena.Application.Queries.Amazon.Profiles.GetProfiles
{
    public class GetProfilesQueryHandler : IRequestHandler<GetProfilesQuery, List<ProfileDto>>
    {
        private readonly IAmazonService _amazonService;
        private readonly UserHelper _userHelper;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetProfilesQueryHandler(IUnitOfWork uow, IMapper mapper, UserHelper userHelper, IAmazonService amazonService)
        {
            _uow = uow;
            _mapper = mapper;
            _userHelper = userHelper;
            _amazonService = amazonService;
        }

        public async Task<List<ProfileDto>> Handle(GetProfilesQuery request, CancellationToken cancellationToken)
        {
            List<ProfileDto> results;
            var userId = _userHelper.GetUserId();
            if (request.Nocache)
            {
                var result = await _amazonService.GetProfilesAsync(userId);

                if (result is null)
                    throw new BadRequestException(ErrorCodes.CalendarEventsNotExists);

                results = JsonConvert.DeserializeObject<List<ProfileDto>>(result);
                foreach (ProfileDto item in results)
                {
                    var currProfile = await _uow.GetReposiotory<AmazonProfile>().GetAsync(item.profileId);
                    if (currProfile is null)
                    {
                        currProfile = _mapper.Map<AmazonProfile>(item);
                        currProfile.UserId = _userHelper.GetUserId();
                        await _uow.GetReposiotory<AmazonProfile>().AddAsync(currProfile);
                    }
                    else
                    {
                        if (_userHelper.GetUserId() != currProfile.UserId)
                            throw new ForbiddenException(ErrorCodes.Forbidden);

                        currProfile = _mapper.Map(item, currProfile);
                        currProfile.UserId = _userHelper.GetUserId();
                    }
                    await _uow.CompleteAsync();
                }
            }
            else
            {
                var profiles = await _uow.GetReposiotory<AmazonProfile>().GetListAsync(x => x.UserId == userId);
                results=profiles.ToList().ConvertAll(x => System.Text.Json.JsonSerializer.Deserialize<ProfileDto>(x.Data,null));
            }
            return results;
        }
    }
}