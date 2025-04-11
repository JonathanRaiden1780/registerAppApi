using ApiTest.Core.Helpers;
using Microsoft.VisualBasic;
using Swashbuckle.AspNetCore.SwaggerUI;
using Constants = ApiTest.Core.Helpers.Constants;

namespace ApiTest.Api.Extensions.Swagger
{
    public static class ConfigureSwaggerUIOptionsExt
    {
        public static SwaggerUIOptions AddSwaggerEndpointsPath(this SwaggerUIOptions c, IConfiguration configuration)
        {
            c.SwaggerEndpoint(Constants.SwaggerPathUsers, Constants.Users);
            return c;
        }
    }
}
