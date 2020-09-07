using ElevaEducacao.Domain;
using ElevaEducacao.Mapper;
using System.Collections.Generic;

namespace ElevaEducacao.ViewModel
{
    public class EscolaEntradaViewModel : IViewModel<Escola>
    {
        public string Nome { get; set; }
        public bool ConvenioPoderPublico { get; set; }
        public bool AtendeEducacaoEspecial { get; set; }
        public CategoriaAdministrativa CategoriaAdministrativa { get; set; }
        public TipoLocalizacao TipoLocalizacao { get; set; }
        public EnderecoEntradaViewModel Endereco { get; set; }
        public List<ModalidadeViewModel> Modalidades { get; set; }
        public List<TelefoneViewModel> Telefones { get; set; }
    }

    public class EscolaEntradaIdViewModel : EscolaEntradaViewModel
    {
        public int Id { get; set; }
    }

    public class EscolaSaidaViewModel : IViewModel<Escola>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool ConvenioPoderPublico { get; set; }
        public bool AtendeEducacaoEspecial { get; set; }
        public CategoriaAdministrativa CategoriaAdministrativa { get; set; }
        public TipoLocalizacao TipoLocalizacao { get; set; }
        public EnderecoSaidaViewModel Endereco { get; set; }
        public List<ModalidadeSaidaViewModel> Modalidades { get; set; }
        public List<TelefoneSaidaViewModel> Telefones { get; set; }
    }
}
