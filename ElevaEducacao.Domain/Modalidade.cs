using ElevaEducacao.Domain.Core.Entities;

namespace ElevaEducacao.Domain
{
    public class Modalidade : Entity {
        public int IdEscola { get; set; }
        public Escola Escola { get; set; }
        public ModalidadesEnsino IdModalidadeEnsino { get; set; }
    }
}
