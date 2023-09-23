using karavana_APPLICATION.InfraAbstractions;
using karavana_INFRASTRUCTURE.Mapper;
using karavana_INFRASTRUCTURE.Persistence;
using karavana_INFRASTRUCTURE.Persistence.Repositories;
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

            services.AddLogging();
            services.AddAutoMapper(typeof(MapperProfiles));

            services.AddRepositories();

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

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICaravanRepository, CaravanRepository>();

            return services;
        }


    }
}
