using ElevaEducacao.Domain;
using ElevaEducacao.Mapper;

namespace ElevaEducacao.ViewModel
{
    public class TelefoneViewModel : IViewModel<Telefone>
    {
        public int DDD { get; set; }
        public int Numero { get; set; }

    }

    public class TelefoneSaidaViewModel : TelefoneViewModel
    {
        public int Id { get; set; }

    }
}


