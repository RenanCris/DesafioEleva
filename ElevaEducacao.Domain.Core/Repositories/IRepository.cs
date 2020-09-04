using ElevaEducacao.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElevaEducacao.Domain.Core.Repositories
{
    public interface IRepository : IDisposable
    {

    }

    public interface ICreatableRepository<TEntity, in TPrimaryKey> : IRepository
       where TEntity : IEntity<TPrimaryKey>
    {
        Task AddAsync(TEntity entity);
        Task AddAsync(IList<TEntity> entities);
    }

    public interface ICreatableRepository<TEntity> : ICreatableRepository<TEntity, int>
        where TEntity : IEntity<int>
    {

    }

    public interface IUpdatableRepository<TEntity, in TPrimaryKey> : IRepository
        where TEntity : IEntity<TPrimaryKey>
    {
        Task UpdateAsync(TEntity entity);
        Task UpdateAsync(IList<TEntity> entities);
    }

    public interface IUpdatableRepository<TEntity> : IUpdatableRepository<TEntity, int>
        where TEntity : IEntity<int>
    {

    }

    public interface IFindableRepository<TEntity, in TPrimaryKey> : IRepository
        where TEntity : IEntity<TPrimaryKey>
    {
        Task<TEntity> FindByIdAsync(TPrimaryKey id);
        Task<List<TEntity>> FindAllAsync();
    }

    public interface IFindableRepository<TEntity> : IFindableRepository<TEntity, int>
        where TEntity : IEntity<int>
    {

    }

    public interface IDeletableRepository<TEntity, in TPrimaryKey> : IRepository
       where TEntity : IEntity<TPrimaryKey>
    {
        Task DeleteAsync(TPrimaryKey id);
        Task DeleteAsync(TEntity entity);
        Task DeleteAsync(IList<TEntity> entities);
    }

    public interface IDeletableRepository<TEntity> : IDeletableRepository<TEntity, int>
        where TEntity : IEntity<int>
    {

    }

    public interface ICrudRepository<TEntity, in TPrimaryKey> :
       ICreatableRepository<TEntity, TPrimaryKey>,
       IUpdatableRepository<TEntity, TPrimaryKey>,
       IDeletableRepository<TEntity, TPrimaryKey>,
       IFindableRepository<TEntity, TPrimaryKey>
       where TEntity : IEntity<TPrimaryKey>
    {

    }

    public interface ICrudRepository<TEntity> : ICrudRepository<TEntity, int>
        where TEntity : IEntity<int>
    {

    }
}
