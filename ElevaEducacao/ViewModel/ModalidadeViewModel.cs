using ElevaEducacao.Domain;
using ElevaEducacao.Mapper;

namespace ElevaEducacao.ViewModel
{
    public class ModalidadeViewModel : IViewModel<Modalidade>
    {
        public ModalidadesEnsino IdModalidadeEnsino { get; set; }
    }

    public class ModalidadeSaidaViewModel : ModalidadeViewModel
    {
        public int Id { get; set; }
    }
}


