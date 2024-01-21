using Journal.Application.Interfaces;
using Journal.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionString"];
            services.AddDbContext<JournalDbContext>(options =>
            {
                options
                    .UseLazyLoadingProxies()
                    .UseSqlServer(connectionString);
            });
            services.AddScoped<IJournalDbContext>(provider =>
                provider.GetService<JournalDbContext>());
            return services;
        }
    }
}
