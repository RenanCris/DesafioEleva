using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ElevaEducacao.Infra.CrossCutting.Ioc
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterWhoImplements(this IServiceCollection service, Type interfaceType, Assembly[] assemblies, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            var types = assemblies.SelectMany(x => x.GetTypes()).ToList();

            var interfaces = types
                .Where(x => !x.IsClass && x.GetInterfaces().Contains(interfaceType)).Select(x => x).ToList();

            foreach (var i in interfaces)
            {
                var classe = types.Where(x =>
                    x.IsClass && !x.IsAbstract && x.GetInterfaces().Contains(interfaceType) &&
                    x.GetInterfaces().Contains(i)).Select(x => x).FirstOrDefault();

                if (classe == null)
                    continue;

                switch (lifetime)
                {
                    case ServiceLifetime.Singleton:
                        service.AddSingleton(i, classe);
                        break;
                    case ServiceLifetime.Scoped:
                        service.AddScoped(i, classe);
                        break;
                    case ServiceLifetime.Transient:
                        service.AddTransient(i, classe);
                        break;
                }
            }

            return service;
        }
    }
}
