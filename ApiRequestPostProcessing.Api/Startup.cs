using ApiRequestPostProcessing.Api.Filters;
using ApiRequestPostProcessing.Api.Requests.User;
using ApiRequestPostProcessing.Api.ResponseStrategies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using RequestInjector.NetCore;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;
using System.Linq;

namespace ApiRequestPostProcessing.Api
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
            services.Scan(scan => scan
                .FromAssembliesOf(typeof(IRequest), typeof(GetUserRequest))
                .AddClasses()
                .AsSelf()
                .WithTransientLifetime());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Api Request Post Processing", Version = "v1" });
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "ApiRequestPostProcessing.Api.xml");
                c.IncludeXmlComments(xmlPath);

                c.OperationFilter<HeaderOperationFilter>();
            });

            var provider = services.BuildServiceProvider();

            services.AddMvc(config =>
            {
                config.ModelMetadataDetailsProviders.Add(new RequestInjectionMetadataProvider());
                config.ModelBinderProviders.Insert(0, new QueryModelBinderProvider(provider));
                config.Filters.Add(new ResponseFilter(new UserResponseStrategyFactory()));
            })
            .AddJsonOptions(options =>
            {
                options.SerializerSettings.Converters.Add(new RequestInjectionHandler<IRequest>(provider));
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Request Post Processing");
                c.ShowRequestHeaders();
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
