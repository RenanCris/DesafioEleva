using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using ElevaEducacao.Infra.CrossCutting.Ioc;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using ElevaEducacao.Domain.Core.Repositories;
using ElevaEducacao.Infra.CrossCutting.AutoInjector;
using ElevaEducacao.Domain.Core.Interfaces;
using ElevaEducacao.Infra.CrossCutting.NotificationPattern;

namespace ElevaEducacao.Infra.CrossCutting
{
    public static class Bootstrapper
    {
        public static void RegisterServicesBasedOn<TUserKey>(IServiceCollection services, params Assembly[] assemblies)
            where TUserKey : struct
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<INotificationContext, NotificationContext>();

            services.RegisterWhoImplements(typeof(IRepository), assemblies);
            services.RegisterWhoImplements(typeof(IService), assemblies);
            services.RegisterWhoImplements(typeof(ITransientService), assemblies, ServiceLifetime.Transient);
            services.RegisterWhoImplements(typeof(ISingletonService), assemblies, ServiceLifetime.Singleton);
            services.RegisterWhoImplements(typeof(IUnitOfWork), assemblies);
        }
    }
}
