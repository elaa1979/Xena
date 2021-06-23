using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using Xena.Application.Utils;
using Microsoft.AspNetCore.Http;

namespace Xena.Api.Infrastructure.Middlewares
{
    public class BlackListTokenMiddleware
    {
        private readonly RequestDelegate _next;
        public BlackListTokenMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context,TokenService tokenService)
        {
            var token = context.Request.Headers["Authorization"].ToString().Split(" ").Last();
            if (await tokenService.IsBlackListed(token))
                throw new AuthenticationException("Invalid token");
            await _next(context);
        }
    }
}