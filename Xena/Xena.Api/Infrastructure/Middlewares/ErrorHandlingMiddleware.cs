using System;
using System.Net;
using System.Security.Authentication;
using System.Threading.Tasks;
using Xena.Application.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Xena.Api.Infrastructure.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;


        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (AuthenticationException ex)
            {
                await catchError(ex, HttpStatusCode.Unauthorized);
            }
            catch (ValidationException ex)
            {
                await catchError(ex, HttpStatusCode.BadRequest);
            }
            catch (BadRequestException ex)
            {
                await catchError(ex, HttpStatusCode.BadRequest);
            }
            catch (ForbiddenException ex)
            {
                await catchError(ex, HttpStatusCode.Forbidden);
            }
            catch (Exception ex)
            {
                await catchError(ex, HttpStatusCode.InternalServerError);
            }

            async Task catchError(Exception ex, HttpStatusCode statusCode)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.StatusCode = (int)statusCode;
                context.Response.ContentType = "application/json; charset=utf-8";
                var message = statusCode == HttpStatusCode.InternalServerError ? ErrorCodes.InternalServerError : ex.Message;
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new Error { ErrorMessage = message }));
            }
        }
    }

}