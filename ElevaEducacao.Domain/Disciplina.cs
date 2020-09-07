using ElevaEducacao.Domain.Core.Entities;
using System.Collections.Generic;

namespace ElevaEducacao.Domain
{
    public class Disciplina : Entity{
        public string Descricao { get; set; }
        public virtual List<TurmaDisciplina> Turmas { get; set; }
    }
}
