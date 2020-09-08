using ElevaEducacao.Domain.Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElevaEducacao.Domain.Interfaces.Repository
{
    public interface ICidadeRepository : IRepository<Cidade>
    {
        Task<List<Cidade>> ObterPorUF(int idUF);
    }
}
