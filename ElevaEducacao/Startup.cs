using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElevaEducacao.Extension;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.SwaggerUI;
using ElevaEducacao.Infra.CrossCutting.MediatR;
using ElevaEducacao.Infra.CrossCutting;

namespace ElevaEducacao
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var assemblies = new[]
           {
                typeof(Startup).Assembly,
                typeof(Domain.Core.Entities.Entity).Assembly,
                typeof(Infra.EFCore.Extensions.CustomDbContextOptionsBuilder).Assembly,
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

            Bootstrapper.RegisterServicesBasedOn<Guid>(services, assemblies);

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
            app.UseExceptionHandlers();

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
