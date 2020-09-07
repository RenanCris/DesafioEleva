using ElevaEducacao.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ElevaEducacao.Domain.Core.Repositories
{
    public interface IRepository : IDisposable
    {
    }

    public interface IRepository<TEntity> : IRepository 
        where TEntity : Entity
    {
        Task Criar(TEntity obj);
        Task Criar(IList<TEntity> list);
        Task Atualizar(TEntity obj);
        Task Atualizar(IList<TEntity> list);
        Task Excluir(int id);
        Task ExcluirPermanentemente(int id);
        Task ExcluirPermanentemente(TEntity obj);
        Task ExcluirPermanentemente(IList<TEntity> list);
        Task<TEntity> ObterPorId(int id);
        Task<List<TEntity>> ObterTodos();
        Task<List<TEntity>> Buscar(Expression<Func<TEntity, bool>> condicao);
        Task<bool> Existe(int id);

    }
}
