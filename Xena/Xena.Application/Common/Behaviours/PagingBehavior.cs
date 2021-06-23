using System.Threading;
using System.Threading.Tasks;
using Xena.Application.Common.Models;
using MediatR;

namespace Xena.Application.Common.Behaviours
{
    public class PagingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
               where TRequest : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (request is BaseRequest pagingRequest)
            {
                if (pagingRequest.Page < 1)
                    pagingRequest.Page = 1;
                if (pagingRequest.PerPage < 1)
                    pagingRequest.PerPage = 10;
            }

            return await next();
        }
    }
}