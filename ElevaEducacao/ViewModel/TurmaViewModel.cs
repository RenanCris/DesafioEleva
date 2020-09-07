using ElevaEducacao.Domain;
using ElevaEducacao.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElevaEducacao.ViewModel
{
    public class TurmaEntradaViewModel : IViewModel<Turma>
    {
        public string CodigoPesquisa { get; set; }
        public int IdEscola { get; set; }
        public int HorasAula { get; set; }
        public int TotalVagas { get; set; }
        public int TotalVagasOcupadas { get; set; }
    }

    public class TurmaSaidaViewModel : TurmaEntradaViewModel
    {
        public int Id { get; set; }
        public int TotalVagasDisponiveis { get; set; }
    }

}
