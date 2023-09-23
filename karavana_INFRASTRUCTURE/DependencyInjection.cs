using karavana_INFRASTRUCTURE.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karavana_INFRASTRUCTURE
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddSqlDb(configuration);
            return services;
        }

        public static IServiceCollection AddSqlDb(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("AppSqlDb"));
            });
            return services;
        }

    }
}
