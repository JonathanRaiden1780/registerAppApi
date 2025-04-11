using System.Text;
using Microsoft.IdentityModel.Tokens;
using ApiTest.Core.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ApiTest.Core.Contracts.Factories.Common;
using ApiTest.Repositories;
using ApiTest.Services;
using enums = ApiTest.Core.Enums;

namespace ApiTest.Api.Extensions
{
    public static class ServiceDependencyInjection
    {
        public static IServiceCollection AddInyeccionDependencias(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCorsSpecificOriginsPolicy(configuration);
            services.AddServiceAuthApi();
            services.DependencyInjection();
            services.AddServiceFactories();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
        private static IServiceCollection AddServiceAuthApi(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opciones => opciones.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable(Constants.SecretKey))
                    ),
                    ClockSkew = TimeSpan.Zero
                });


            return services;
        }
        private static IServiceCollection DependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<ServiceFactory>();
            return services;
        }
        private static IServiceCollection AddServiceFactories(this IServiceCollection services)
        {
            services.AddScoped<Func<string, IServiceFactory>>(serviceFactory => key =>
            {
                return key switch
                {
                    nameof(enums.Catalogs.Test) => serviceFactory.GetService<ServiceFactory>()
                };
            });

            return services;
        }
    }
}
