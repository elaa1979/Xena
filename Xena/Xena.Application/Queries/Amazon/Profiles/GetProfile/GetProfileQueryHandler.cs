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

namespace Xena.Application.Queries.Amazon.Profiles.GetProfile
{
    public class GetProfilesQueryHandler : IRequestHandler<GetProfileQuery, ProfileDto>
    {
        private readonly IAmazonService _amazonService;
        private readonly UserHelper _userHelper;

        public GetProfilesQueryHandler(UserHelper userHelper, IAmazonService amazonService)
        {
            _userHelper = userHelper;
            _amazonService = amazonService;
        }

        public async Task<ProfileDto> Handle(GetProfileQuery request, CancellationToken cancellationToken)
        {
            //var userId = _userHelper.GetUserId();
            //var result = await _amazonService.GetProfilesAsync(userId);

            //if (result is null)
            //    throw new BadRequestException(ErrorCodes.AmazonProfileNotExists);

            //ProfileDto profile = JsonConvert.DeserializeObject<ProfileDto>(result);
            //return profile;
            return null;
        }
    }
}