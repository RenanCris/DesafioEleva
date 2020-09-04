using AutoMapper;
using ElevaEducacao.Domain.Core.Commands;
using ElevaEducacao.Domain.Core.Entities;
using ElevaEducacao.Infra.CrossCutting.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ElevaEducacao.Mapper
{
    public static class MapperHelper
    {
        public static void ApplyAutoMappings(this Profile profile, params Assembly[] assemblies)
        {
            profile.ApplyExplicityMappingsFor(assemblies);
            profile.ApplyImplicityMappingsFor(assemblies);
        }

        private static void ApplyExplicityMappingsFor(this Profile profile, params Assembly[] assemblies)
        {
            var types = assemblies
                .SelectMany(x => x.GetTypes())
                .Where(t => t.IsClass
                            && !t.IsAbstract
                            && t.HasMappableInterface())
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);

                var methodInfo = type.GetMethod("Mapping")
                                 ?? type.GetInterface("IMapFrom`1")?.GetMethod("Mapping");

                methodInfo?.Invoke(instance, new object[] { profile });
            }
        }
        private static void ApplyImplicityMappingsFor(this Profile profile, params Assembly[] assemblies)
        {
            var allTypes = assemblies
                .SelectMany(x => x.GetTypes())
                .ToList();

            var viewModels = allTypes
                .Where(t => t.IsClass
                            && !t.IsAbstract
                            && t.HasMappableInterface()
                            && t.HasEntityInterface()
                            && allTypes.HasCommandsFor(t.GetEntityTypeFromGenericTypeArgumentsOf(typeof(IViewModel<>))))
                .ToList();

            foreach (var vm in viewModels)
            {
                var entity = vm.GetEntityTypeFromGenericTypeArgumentsOf(typeof(IViewModel<>));
                var commands = allTypes
                    .Where(t => t.IsClass
                                && !t.IsAbstract
                                && t.GetInterfaces()
                                    .Any(i => i.IsCommandInterface()
                                              && (t.GetEntityTypeFromGenericTypeArgumentsOf(typeof(ICommandMapped<>)) == entity
                                                  || t.GetEntityTypeFromGenericTypeArgumentsOf(typeof(ICommandMapped<,>)) == entity
                                                  || t.GetEntityTypeFromGenericTypeArgumentsOf(typeof(ICommandMapped<,,>)) == entity)))
                    .ToList();

                foreach (var command in commands)
                {
                    profile.CreateMap(vm, command);
                }
            }
        }

        private static bool HasMappableInterface(this Type type)
        {
            return type.GetInterfaces().Any(i => i.IsMappableInterface());
        }
        private static bool HasEntityInterface(this Type type)
        {
            return type.GetInterfaces()
                .Any(i => i.IsViewModelInterface()
                          && i.HasAnEntityAsGenericTypeArgument());
        }
        private static bool HasAnEntityAsGenericTypeArgument(this Type type)
        {
            return type.IsGenericType
                && type.GenericTypeArguments.Any(p => p.IsAnEntityClass());
        }
        private static bool HasCommandsFor(this IEnumerable<Type> types, Type entity)
        {
            var result = types.Any(x => x.IsClass
                                        && !x.IsAbstract
                                        && x.GetInterfaces().Any(i =>
                                            i.IsCommandInterface()
                                            && (x.GetEntityTypeFromGenericTypeArgumentsOf(typeof(ICommandMapped<>)) == entity
                                                || x.GetEntityTypeFromGenericTypeArgumentsOf(typeof(ICommandMapped<,>)) == entity
                                                || x.GetEntityTypeFromGenericTypeArgumentsOf(typeof(ICommandMapped<,,>)) == entity)));

            return result;
        }

        private static bool IsMappableInterface(this Type type)
        {
            return type.IsInterface
                   && type.IsGenericType
                   && type.GetGenericTypeDefinition() == typeof(IMapFrom<>);
        }
        private static bool IsViewModelInterface(this Type type)
        {
            return type.IsInterface
                   && type.IsGenericType
                   && type.GetGenericTypeDefinition() == typeof(IViewModel<>);
        }
        private static bool IsCommandInterface(this Type type)
        {
            var result = type.IsInterface
                         && type.IsGenericType
                         && (type.GetGenericTypeDefinition() == typeof(ICommandMapped<>)
                             || type.GetGenericTypeDefinition() == typeof(ICommandMapped<,>)
                             || type.GetGenericTypeDefinition() == typeof(ICommandMapped<,,>));

            return result;
        }
        private static bool IsAnEntityClass(this Type type)
        {
            return type.GetInterfaces().Any(i => i == typeof(IDomainEntity));
        }

        private static Type GetEntityTypeFromGenericTypeArgumentsOf(this Type type, Type interfaceType)
        {
            var result = type.GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == interfaceType)
                .SelectMany(i => i.GenericTypeArguments)
                .FirstOrDefault(a => a.IsAnEntityClass());

            return result;
        }
    }
}
