using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using EServicesWithAngular.Mapper;
using System;
using EServicesWithAngular.Helpers;
using EServicesCommon.DI;
using EServicesWithAngular.MiddleWare;
using Newtonsoft.Json;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Hosting;
using System.Linq;
using CommonLibrary.Logging;

namespace EServicesWithAngular
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            var builder = new ConfigurationBuilder().
                SetBasePath(env.ContentRootPath).
                AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, true).
                AddEnvironmentVariables();
              
        }

        public static IConfiguration Configuration { get; set; }
        public static IMapper Mapper;

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc(config => config.Filters.Add(new ValidationFilterAttribute())).AddJsonOptions(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            services.AddMvc(option => option.EnableEndpointRouting = false).AddNewtonsoftJson(options =>
            { new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }; });


            services.AddMemoryCache();
            //autoMapper
            var mappingConfig = new MapperConfiguration(mc =>
            {
                // mc.AddProfile(new MCMappingProfile());
                mc.AddProfile(new MappingProfile());
            });

            Mapper = mappingConfig.CreateMapper();
            services.AddSingleton(Mapper);


            services.Configure(Configuration);
            services.AddCors();

            services.AddAuthentication(IISDefaults.AuthenticationScheme);
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "ERP API",
                    Description = "To offer ERP services",

                });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
            return FactoryManager.Instance.LoadConfiguaration(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerManager _logger)
        {

            app.UseDeveloperExceptionPage();
            app.UseMiddleware<ExceptionMiddleWare>();
            app.UseMiddleware<LoggingMiddleWare>();

            //app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseSpaStaticFiles();

            app.UseCors(options =>
            {
                options
               .AllowAnyHeader()
               .AllowAnyMethod()
               .WithOrigins(
               "http://es:8080",
               "http://localhost:4200",
               "http://des:8080",
               "http://kta-web-601:8080",
               "http://kta-web-401:8080",
               "http://localhost:57708")
               .WithExposedHeaders("X-Pagination");
            });

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseMvc();

            // Creates Swagger JSON
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "api/docs/{documentName}/swagger.json";
            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/api/docs/v1/swagger.json", "EService API V1");
                c.RoutePrefix = "api/docs";
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });


        }
    }
}
