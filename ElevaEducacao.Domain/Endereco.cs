using ElevaEducacao.Domain.Core.Entities;

namespace ElevaEducacao.Domain
{
    public class Endereco : Entity
    {
        public int IdCidade { get; set; }
        public int IdBairro { get; set; }
        public Cidade Cidade { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Descricao { get; set; }
        public Bairro Bairro { get; set; }

        public int IdEscola { get; set; }
        public Escola Escola { get; set; }
    }
}
