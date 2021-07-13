using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Xena.Application.Abstractions.Repositories;
using Xena.Application.Common.Exceptions;
using Xena.Application.Utils;
using Xena.Domain.Amazon;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Xena.Application.Queries.Amazon.AdGroups.GetAdGroup
{
    public class GetAdGroupQueryHandler : IRequestHandler<GetAdGroupQuery, AdGroupDto>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly UserHelper _userHelper;
        public GetAdGroupQueryHandler(IUnitOfWork uow, IMapper mapper, UserHelper userHelper)
        {
            _uow = uow;
            _mapper = mapper;
            _userHelper = userHelper;
        }
        public async Task<AdGroupDto> Handle(GetAdGroupQuery request, CancellationToken cancellationToken)
        {
            var adGroup = await _uow.GetReposiotory<AmazonAdGroup>().GetAsync(request.Id);
            return _mapper.Map<AdGroupDto>(adGroup);
        }
    }
}