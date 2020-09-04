using AutoMapper;
using ElevaEducacao.Infra.CrossCutting.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ElevaEducacao.Extension
{
    public static class AutoMapperExtensions
    {
        public static void AddAutoMapperWithSettings(this IServiceCollection services, Action<AutoMapperSettings> autoMapperSettingsBuilder, params Assembly[] assemblies)
        {
            var autoMapperSettings = new AutoMapperSettings();
            autoMapperSettingsBuilder(autoMapperSettings);
            services.AddSingleton(new AutoMapperAssemblies(assemblies));

            services.AddAutoMapper(opt =>
            {
                if (autoMapperSettings.UseStringTrimmingTransformers)
                    opt.ValueTransformers.Add<string>(value => value != null ? value.Trim() : null);
            }, assemblies);
        }

        public class AutoMapperSettings
        {
            public bool UseStringTrimmingTransformers { get; set; }
        }
    }
}
