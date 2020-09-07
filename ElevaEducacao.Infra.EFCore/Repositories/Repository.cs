using ElevaEducacao.Domain.Core.Entities;
using ElevaEducacao.Domain.Core.Repositories;
using ElevaEducacao.Infra.EFCore.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ElevaEducacao.Infra.EFCore.Repositories
{
    public abstract class Repository
    {
        private readonly DbContext _context;
        protected Repository(DbContext context)
        {
            _context = context;
        }
    }

    public abstract class RepositoryBase<TEntity> : Repository, IRepository<TEntity>
        where TEntity : Entity
    {
        protected DbSet<TEntity> DbSet;
        protected readonly ApplicationDbContext Context;
        
        protected RepositoryBase(ApplicationDbContext context) : base(context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public virtual async Task Criar(TEntity obj)
        {
            await DbSet.AddAsync(obj);
        }

        public virtual async Task Criar(IList<TEntity> list)
        {
            await DbSet.AddRangeAsync(list);
        }

        public virtual Task Atualizar(TEntity obj)
        {
            DbSet.Update(obj);
            return Task.CompletedTask;
        }

        public virtual Task Atualizar(IList<TEntity> list)
        {
            DbSet.UpdateRange(list);
            return Task.CompletedTask;
        }

        public virtual async Task Excluir(int id)
        {
            var obj = await DbSet.FindAsync(id);
            DbSet.Remove(obj);
        }

        public virtual async Task ExcluirPermanentemente(int id)
        {
            var obj = await DbSet.FindAsync(id);
            await ExcluirPermanentemente(obj);
        }

        public virtual Task ExcluirPermanentemente(TEntity obj)
        {
            Context.Remove(obj);
            return Task.CompletedTask;
        }

        public virtual Task ExcluirPermanentemente(IList<TEntity> list)
        {
            Context.RemoveRange(list);
            return Task.CompletedTask;
        }

        public virtual async Task<TEntity> ObterPorId(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<bool> Existe(int id)
        {
            return await DbSet.AnyAsync(x => x.Id == id);
        }

        public virtual Task<List<TEntity>> ObterTodos()
        {
            return DbSet.ToListAsync();
        }

        public virtual Task<List<TEntity>> Buscar(Expression<Func<TEntity, bool>> condicao)
        {
            return DbSet
                .Where(condicao)
                .ToListAsync();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
