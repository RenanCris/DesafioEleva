using ElevaEducacao.Domain;
using ElevaEducacao.Mapper;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ElevaEducacao.ViewModel
{
    public class EnderecoEntradaViewModel : IViewModel<Endereco>
    {
        public int IdCidade { get; set; }
        public int IdBairro { get; set; }
        public int IdEscola { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Descricao { get; set; }
    }


    public class EnderecoSaidaViewModel : IViewModel<Endereco>
    {
        public CidadeSaidaViewModel Cidade { get; set; }
        public BairroSaidaViewModel Bairro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Descricao { get; set; }
    }
}
