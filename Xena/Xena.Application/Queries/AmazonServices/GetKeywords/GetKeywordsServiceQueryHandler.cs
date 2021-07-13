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

namespace Xena.Application.Queries.AmazonServices.GetKeywords
{
    public class GetKeywordsServiceQueryHandler : IRequestHandler<GetKeywordsServiceQuery, List<KeywordDto>>
    {
        private readonly IAmazonService _amazonService;
        private readonly UserHelper _userHelper;

        public GetKeywordsServiceQueryHandler(UserHelper userHelper, IAmazonService amazonService)
        {
            _userHelper = userHelper;
            _amazonService = amazonService;
        }

        public async Task<List<KeywordDto>> Handle(GetKeywordsServiceQuery request, CancellationToken cancellationToken)
        {
            var userId = _userHelper.GetUserId();
            var result = await _amazonService.GetKeywordsAsync(userId, request.ProfileId);

            if (result is null)
                throw new BadRequestException(ErrorCodes.CalendarEventsNotExists);

            List<KeywordDto> events = JsonConvert.DeserializeObject<List<KeywordDto>>(result);
            return events;
        }
    }
}