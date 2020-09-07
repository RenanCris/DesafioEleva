using System;

using ElevaEducacao.Extension;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.SwaggerUI;
using ElevaEducacao.Infra.CrossCutting.MediatR;
using ElevaEducacao.Infra.CrossCutting;
using Microsoft.Extensions.Configuration;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using ElevaEducacao.Infra.EFCore.Context;
using ElevaEducacao.Infra.EFCore.Extensions;
using ElevaEducacao.Domain;

namespace ElevaEducacao
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        [Obsolete]
        private readonly IHostingEnvironment _environment;

        [Obsolete]
        public Startup(IHostingEnvironment env)
        {
            _environment = env;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            var assemblies = new[]
           {
                typeof(Startup).Assembly,
                typeof(Domain.Core.Entities.Entity).Assembly,
                typeof(Infra.EFCore.Extensions.CustomDbContextOptionsBuilder).Assembly,
                typeof(MediatrAssemblies).Assembly,
                typeof(Escola).Assembly,
            };

            services.AddMvc();

            services.AddHealthChecks();
            services.AddMediatr(assemblies);

            services.AddSwaggerDocumentation(() => new SwaggerSettings
            {
                ApiTitle = "Api Educação Elev@",
                ApiDescription = "Case de demostração",
                ApiContactInfo = "renancris21@gmail.com",
                SecureWithUseJwtAuth = false
            });

            services.AddAutoMapperWithSettings(settings =>
            {
                settings.UseStringTrimmingTransformers = true;
            }, assemblies);
            
           Bootstrapper.RegisterServicesBasedOn<Guid>(services, Configuration, assemblies);

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(c =>
            {
                c.AllowAnyHeader()
                      .SetIsOriginAllowed(origin => true);

                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseRouting();
            app.UseExceptionHandlers("Houve algum erro ao executar a aplicação");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });

            app.UseSwaggerDocumentation(() => new SwaggerUiSettings
            {
                ApiTitle = "Api Case Teste",
                ApiDocExpansion = DocExpansion.Full
            });
        }
    }
}
