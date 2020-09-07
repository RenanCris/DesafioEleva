using ElevaEducacao.Domain.Core.Repositories;
using System.Threading.Tasks;

namespace ElevaEducacao.Domain.Interfaces.Repository
{
    public interface ITurmaRepository : IRepository<Turma>
    {
        Task<bool> ExisteTurmaParaCodigoPesquisa(Turma  turma, int? id = null);
    }
}
