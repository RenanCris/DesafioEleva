using ElevaEducacao.Domain;
using ElevaEducacao.Mapper;

namespace ElevaEducacao.ViewModel
{
    public class UFSaidaViewModel : IViewModel<UF>
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
    }

    public class BairroSaidaViewModel : IViewModel<Bairro>
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}


