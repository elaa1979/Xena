using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Xena.Application.Abstractions.Repositories;
using Xena.Application.Common.Models;
using Xena.Domain.Logs;
using MediatR;

namespace Xena.Application.Queries.Logs
{
    public class GetLogsQueryHandler : IRequestHandler<GetLogsQuery, BaseResult<LogDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public GetLogsQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<BaseResult<LogDto>> Handle(GetLogsQuery request, CancellationToken cancellationToken)
        {
            var logs = await _uow.GetReposiotory<Log>().GetPagingListAsync((BaseRequest)request);
            return _mapper.Map<BaseResult<LogDto>>(logs);
        }
    }
}