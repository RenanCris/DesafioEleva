using ElevaEducacao.Domain.Core.Entities;

namespace ElevaEducacao.Domain
{
    public class Telefone : Entity
    {
        public int DDD { get; set; }
        public int Numero { get; set; }

        public int IdEscola { set; get; }
        public Escola Escola { get; set; }
    }
}
