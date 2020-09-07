using ElevaEducacao.Domain.Core.Entities;
using System.Collections.Generic;

namespace ElevaEducacao.Domain
{
    public class Turma : Entity {
        public string CodigoPesquisa { get; set; }
        public int IdEscola { get; set; }
        public Escola Escola { get; set; }
        public int HorasAula { get; set; }
        public int TotalVagas { get; set; }
        public int TotalVagasOcupadas { get; set; }
        public int TotalVagasDisponiveis { get => this.TotalVagas - this.TotalVagasOcupadas; }
        public virtual List<TurmaDisciplina> Disciplinas { get; set; }

    }
}
