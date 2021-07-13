using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Xena.Application.Abstractions.Repositories;
using Xena.Application.Common.Exceptions;
using Xena.Application.Utils;
using Xena.Domain.Amazon;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Xena.Application.Queries.Amazon.Keywords.GetKeyword
{
    public class GetKeywordQueryHandler : IRequestHandler<GetKeywordQuery, KeywordDto>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly UserHelper _userHelper;
        public GetKeywordQueryHandler(IUnitOfWork uow, IMapper mapper, UserHelper userHelper)
        {
            _uow = uow;
            _mapper = mapper;
            _userHelper = userHelper;
        }
        public async Task<KeywordDto> Handle(GetKeywordQuery request, CancellationToken cancellationToken)
        {
            var keyword = await _uow.GetReposiotory<AmazonKeyword>().GetAsync(request.Id);
            return _mapper.Map<KeywordDto>(keyword);
        }
    }
}