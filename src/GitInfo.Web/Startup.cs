using System;
using GitInfo.Ioc.Injectors;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace GitInfo.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            DependencyInjector.RegisterServices(services);
            RegisterClients(services, Configuration);
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GitInfo.Web", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GitInfo.Web v1"));
            }
            app.UseCors(c =>
                      {
                          c.AllowAnyHeader();
                          c.AllowAnyMethod();
                          c.AllowAnyOrigin();
                      });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void RegisterClients(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient("Github.API", httpClient => 
            {
                httpClient.BaseAddress = new Uri(configuration.GetSection("Github.API:BaseUrl").Value);
            });
        }
    }
}
