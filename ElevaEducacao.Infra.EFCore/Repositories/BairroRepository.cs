using ElevaEducacao.Domain;
using ElevaEducacao.Domain.Interfaces.Repository;
using ElevaEducacao.Infra.EFCore.Context;

namespace ElevaEducacao.Infra.EFCore.Repositories
{
    public class BairroRepository : RepositoryBase<Bairro>, IBairroRepository
    {
        public BairroRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
