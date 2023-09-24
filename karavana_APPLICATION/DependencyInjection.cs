using karavana_APPLICATION.InfraAbstractions;
using karavana_APPLICATION.ServiceAbstractions;
using karavana_APPLICATION.ServiceImplementations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karavana_APPLICATION
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICaravanService, CaravanService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICompanyService, CompanyService>();


            return services;
        }

    }
}
