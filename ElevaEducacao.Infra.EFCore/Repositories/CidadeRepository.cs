using ElevaEducacao.Domain;
using ElevaEducacao.Domain.Interfaces.Repository;
using ElevaEducacao.Infra.EFCore.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElevaEducacao.Infra.EFCore.Repositories
{
    public class CidadeRepository : RepositoryBase<Cidade>, ICidadeRepository
    {
        public CidadeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Cidade>> ObterPorUF(int idUF)
        {
            return await this.Buscar(X => X.UF.Id == idUF);
        }
    }
}
