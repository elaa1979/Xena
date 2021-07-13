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

namespace Xena.Application.Queries.Amazon.Keywords.GetKeywords
{
    public class GetKeywordsQueryHandler : IRequestHandler<GetKeywordsQuery, List<KeywordDto>>
    {
        private readonly IAmazonService _amazonService;
        private readonly UserHelper _userHelper;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetKeywordsQueryHandler(IUnitOfWork uow, IMapper mapper, UserHelper userHelper, IAmazonService amazonService)
        {
            _uow = uow;
            _mapper = mapper;
            _userHelper = userHelper;
            _amazonService = amazonService;
        }

        public async Task<List<KeywordDto>> Handle(GetKeywordsQuery request, CancellationToken cancellationToken)
        {
            List<KeywordDto> results;
            var userId = _userHelper.GetUserId();
            if (request.Nocache)
            {
                var result = await _amazonService.GetKeywordsAsync(userId, request.ProfileId);

                if (result is null)
                    throw new BadRequestException(ErrorCodes.CalendarEventsNotExists);

                results = JsonConvert.DeserializeObject<List<KeywordDto>>(result);
                foreach (KeywordDto item in results)
                {
                    var currKeyword = await _uow.GetReposiotory<AmazonKeyword>().GetAsync(item.keywordId);
                    if (currKeyword is null)
                    {
                        currKeyword = _mapper.Map<AmazonKeyword>(item);
                        currKeyword.profileId = request.ProfileId;
                        currKeyword.UserId = _userHelper.GetUserId();
                        await _uow.GetReposiotory<AmazonKeyword>().AddAsync(currKeyword);
                    }
                    else
                    {
                        if (_userHelper.GetUserId() != currKeyword.UserId)
                            throw new ForbiddenException(ErrorCodes.Forbidden);

                        currKeyword = _mapper.Map(item, currKeyword);
                        currKeyword.profileId = request.ProfileId;
                        currKeyword.UserId = _userHelper.GetUserId();
                    }
                    await _uow.CompleteAsync();
                }
            }
            else
            {
                var keywords = await _uow.GetReposiotory<AmazonKeyword>().GetListAsync(x => x.UserId == userId);
                results = _mapper.Map<List<KeywordDto>>(keywords.ToList());
                results = keywords.ToList().ConvertAll(x =>
                {
                    KeywordDto keywordDto = System.Text.Json.JsonSerializer.Deserialize<KeywordDto>(x.Data, null);
                    keywordDto.profileId = request.ProfileId;
                    return keywordDto;
                });
            }
            return results;
        }
    }
}