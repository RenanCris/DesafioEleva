using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ElevaEducacao.Infra.EFCore.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void ApplyVarcharConvention(this ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var entity in entityType.GetProperties())
                {
                    if (entity.ClrType == typeof(string) || entity.DeclaringEntityType.ClrType == typeof(string))
                        entity.SetIsUnicode(false);
                }
            }
        }

        public static void ApplyDateTimeConvention(this ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var entity in entityType.GetProperties())
                {
                    if (entity.ClrType == typeof(DateTime) || entity.DeclaringEntityType.ClrType == typeof(DateTime) || entity.ClrType == typeof(DateTime?) || entity.DeclaringEntityType.ClrType == typeof(DateTime?))
                    {
                        entity.SetColumnType("datetime2");
                    }
                }
            }
        }

        public static void ApplyMappings(this ModelBuilder modelBuilder, Assembly assembly)
        {
            var applyGenericMethods = typeof(ModelBuilder).GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
            var applyGenericApplyConfigurationMethods = applyGenericMethods.Where(m => m.IsGenericMethod && m.Name.Equals("ApplyConfiguration", StringComparison.OrdinalIgnoreCase));
            var applyGenericMethod = applyGenericApplyConfigurationMethods.FirstOrDefault(m => m.GetParameters().FirstOrDefault()?.ParameterType.Name == "IEntityTypeConfiguration`1");
            var mappingClasses = assembly.GetTypes()
                .Where(c => c.IsClass
                            && !c.IsAbstract
                            && !c.ContainsGenericParameters
                            && c.GetInterfaces().Any(i => i.IsConstructedGenericType
                                                          && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)))
                .ToList();

            foreach (var type in mappingClasses)
            {
                var interfaceType = type.GetInterfaces()
                    .FirstOrDefault(i => i.IsConstructedGenericType
                                && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>));

                if (interfaceType == null) continue;
                var applyConcreteMethod = applyGenericMethod?.MakeGenericMethod(interfaceType.GenericTypeArguments[0]);
                applyConcreteMethod?.Invoke(modelBuilder, new[] { Activator.CreateInstance(type) });
            }
        }

        public static void DisableCascadeDelete(this ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
