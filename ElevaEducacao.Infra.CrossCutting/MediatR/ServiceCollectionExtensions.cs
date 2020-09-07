using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using MediatR;

namespace ElevaEducacao.Infra.CrossCutting.MediatR
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMediatr(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddMediatR(assemblies);
            services.AddSingleton(new MediatrAssemblies(assemblies).Assemblies);
            return services;
        }

        
    }
}
