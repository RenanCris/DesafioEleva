using ElevaEducacao.Domain;
using ElevaEducacao.Domain.Interfaces.Repository;
using ElevaEducacao.Infra.EFCore.Context;
using Microsoft.EntityFrameworkCore.Internal;
using System.Threading.Tasks;
using System.Linq;

namespace ElevaEducacao.Infra.EFCore.Repositories
{
    public class EnderecoRepository : RepositoryBase<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> VerificarSeExisteEscolaNoEndereco(Endereco end, int? id = null)
        {
            var _result = await this.Buscar(x => x.Descricao == end.Descricao
                && x.Cidade.Id == end.Cidade.Id
                && x.Bairro.Id == end.Bairro.Id
                && x.Numero == end.Numero);

            if(id.HasValue)
                return _result.Any(x=> x.Id != id.Value);

            return _result.Any();
        }
    }
}
