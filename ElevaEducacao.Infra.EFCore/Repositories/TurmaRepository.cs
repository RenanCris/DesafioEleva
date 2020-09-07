using ElevaEducacao.Domain;
using ElevaEducacao.Domain.Interfaces.Repository;
using ElevaEducacao.Infra.EFCore.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElevaEducacao.Infra.EFCore.Repositories
{
    public class TurmaRepository : RepositoryBase<Turma>, ITurmaRepository
    {
        public TurmaRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> ExisteTurmaParaCodigoPesquisa(Turma turma, int? id = null)
        {
            return (await Buscar(x => x.CodigoPesquisa == turma.CodigoPesquisa)).Any();
        }

        public override async Task<List<Turma>> ObterTodos()
        {
            return await Context.Turma.Include(x => x.Escola).ToListAsync();
        }
    }
}
