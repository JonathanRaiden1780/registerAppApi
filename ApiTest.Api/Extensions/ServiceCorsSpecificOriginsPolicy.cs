﻿using ApiTest.Core.Helpers;

namespace ApiTest.Api.Extensions
{
    public static class ServiceCorsSpecificOriginsPolicy
    {
        public static void AddCorsSpecificOriginsPolicy(this IServiceCollection services, IConfiguration configuration)
        {
            string[] paramUrl = configuration.GetSection(Constants.OriginsPolicy).GetChildren().Select(i => i.Value).ToArray();

            foreach (var url in paramUrl)
            {
                Console.WriteLine($"URL permitida para CORS: {url}");
            }

            services.AddCors(options => {
                options.AddPolicy(name: Constants.OriginsPolicy, builder => { builder.WithOrigins(paramUrl).AllowAnyHeader().AllowAnyMethod(); });
            });
        }
    }
}
