using ElevaEducacao.Domain;
using ElevaEducacao.Mapper;

namespace ElevaEducacao.ViewModel
{
    public class CidadeSaidaViewModel : IViewModel<Cidade>
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}
