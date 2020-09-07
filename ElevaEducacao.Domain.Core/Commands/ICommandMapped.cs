using ElevaEducacao.Domain.Core.Entities;
using ElevaEducacao.Infra.CrossCutting.AutoMapper;
using ElevaEducacao.Infra.CrossCutting.MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElevaEducacao.Domain.Core.Commands
{
    public interface ICommandMapped<TEntity, TKey, out TResponse> : ICommand<TResponse>, IMapFrom<TEntity>
       where TEntity : IEntity<TKey>
    {

    }

    public interface ICommandMapped<TEntity, TKey> : ICommand, IMapFrom<TEntity>
        where TEntity : IEntity<TKey>
    {

    }

    public interface ICommandMapped<TEntity> : ICommandMapped<TEntity, int>
        where TEntity : IEntity<int>
    {
    }

    public interface ICommandMappedId<TEntity> : ICommandMapped<TEntity, int>
       where TEntity : IEntity<int>
    {
        public int Id { get; set; }
    }
}
