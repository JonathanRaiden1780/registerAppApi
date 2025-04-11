using System.Reflection;
using Microsoft.OpenApi.Models;
using ApiTest.Core.Helpers;

namespace ApiTest.Api.Extensions.Swagger
{
    public static class ServiceSwagger
    {
        public static IServiceCollection AddServiceSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
               
  
                c.SwaggerDoc(Constants.Users, new OpenApiInfo
                {
                    Version = Constants.ServiceVersion,
                    Title = Constants.UsersTitle
                });


                c.AddSecurityDefinition(Constants.Bearer, new OpenApiSecurityScheme
                {
                    Name = Constants.DefinitionName,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = Constants.Bearer,
                    BearerFormat = Constants.BearerFormat,
                    In = ParameterLocation.Header
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = Constants.Bearer
                            }
                        },
                        new string[]{}
                    }
                });

                c.OperationFilter<CustomHeaderSwaggerAttribute>();
                c.OperationFilter<CustomQuerySwaggerAttribute>();
                c.CustomSchemaIds(x => x.Name.Replace(Constants.Dto, string.Empty));

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}{Constants.SwaggerExtensionXml}";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });


            return services;
        }
    }
}
