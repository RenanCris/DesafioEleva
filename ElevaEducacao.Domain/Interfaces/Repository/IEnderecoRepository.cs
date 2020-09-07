using ElevaEducacao.Domain.Core.Repositories;
using System.Threading.Tasks;

namespace ElevaEducacao.Domain.Interfaces.Repository
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<bool> VerificarSeExisteEscolaNoEndereco(Endereco end, int? id = null);
    }
}
