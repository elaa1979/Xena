using Xena.Application.Common.Models;
using MediatR;

namespace Xena.Application.Queries.Logs
{
    public class GetLogsQuery: BaseRequest, IRequest<BaseResult<LogDto>>
    {
        
    }
}