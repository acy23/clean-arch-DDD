using karavana_APPLICATION.InfraAbstractions;
using karavana_DOMAIN.Entites;
using karavana_INFRASTRUCTURE.Mapper;
using karavana_INFRASTRUCTURE.Persistence;
using karavana_INFRASTRUCTURE.Persistence.Auth;
using karavana_INFRASTRUCTURE.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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
            services.AddIdentity();

            services.AddAuth(configuration);

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
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IFavouriteRepository, FavouriteRepository>();
            services.AddScoped<IRatingRepository, RatingRepository>();

            services.AddScoped<ITokenHelper, TokenHelper>();

            return services;
        }

        public static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<JwtSettings>(options =>
            {
                options.Issuer = configuration["Jwt:Issuer"];
                options.Audience = configuration["Jwt:Audience"];
                options.Key = configuration["Jwt:Key"];
            });

            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                });

            return services;
        }

        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<AppDbContext>()
               .AddDefaultTokenProviders(); ;
            
            return services;
        }


    }
}
