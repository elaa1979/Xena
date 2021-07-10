using AutoMapper;
using Xena.Application.Abstractions.Repositories;
using Xena.Application.Abstractions.AmazonServices;
using Xena.Domain.Users;
using Xena.Infrastructure.AmazonServices;
using Xena.Infrastructure.Persistence;
using Xena.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Xena.Infrastructure
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetConnectionString("XenaServerType") == "MySQL")
            {
                services.AddDbContext<XenaContext>(option => option.UseMySQL(configuration.GetConnectionString("Xena")));
            }
            else
            {
                services.AddDbContext<XenaContext>(option => option.UseSqlServer(configuration.GetConnectionString("Xena")));
            }

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }

        public static IServiceCollection AddAmazonServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<IAmazonService, AmazonService>();
            return services;
        }

        public static void UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<XenaContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}