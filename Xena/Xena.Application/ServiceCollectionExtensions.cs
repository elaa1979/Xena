using System.Reflection;
using AutoMapper;
using FluentValidation;
using Xena.Application.Abstractions;
using Xena.Application.Common.Behaviours;
using Xena.Application.Common.Mapping;
using Xena.Application.Utils;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Xena.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PagingBehavior<,>));
            services.AddTransient<TokenService>();
            services.AddTransient<ILogService, LogService>();
            return services;
        }
    }
}