using ElevaEducacao.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElevaEducacao.Infra.EFCore.Mappings
{
    public abstract class EntityMap<TEntity, TEntityKey> : IEntityTypeConfiguration<TEntity>
        where TEntity : Entity<TEntityKey>
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Ignore(x => x.ValidationResult);

            ConfigureEntityBuilder(builder);
        }

        public abstract void ConfigureEntityBuilder(EntityTypeBuilder<TEntity> builder);
    }

    public abstract class EntityMap<TEntity> : EntityMap<TEntity, int>
        where TEntity : Entity<int>
    {

    }
}
