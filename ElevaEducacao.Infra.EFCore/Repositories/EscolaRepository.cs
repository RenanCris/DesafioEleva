using ElevaEducacao.Domain;
using ElevaEducacao.Domain.Interfaces.Repository;
using ElevaEducacao.Infra.EFCore.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElevaEducacao.Infra.EFCore.Repositories
{
    public class EscolaRepository : RepositoryBase<Escola>, IEscolaRepository
    {
        public EscolaRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<List<Escola>> ObterTodos()
        {
            return await Context.Escola
                .Include(x => x.Telefones)
                .Include(x => x.Modalidades)
                .Include(x => x.Endereco)
                    .ThenInclude(x => x.Cidade)
                    .ThenInclude(x => x.UF)
                .Include(x => x.Endereco)
                    .ThenInclude(x => x.Bairro).ToListAsync();
        }
    }
}
