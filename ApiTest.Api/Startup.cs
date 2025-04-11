using System.Text.Json.Serialization;
using ApiTest.Api.Extensions;
using ApiTest.Api.Extensions.Swagger;
using ApiTest.Core.Helpers;
using ApiTest.Core.Helpers.ControllerModelConvention;

namespace ApiTest.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInyeccionDependencias(Configuration);
            services.AddMemoryCache();
            services.AddControllers(config => { config.Conventions.Add(new ControllerModelConvention());})
                    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
            services.AddServiceSwagger();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(Constants.OriginsPolicy);
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.AddSwaggerEndpointsPath(Configuration); });
        }
    }
}
