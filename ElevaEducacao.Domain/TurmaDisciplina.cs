using ElevaEducacao.Domain.Core.Entities;
using System;

namespace ElevaEducacao.Domain
{
    public class TurmaDisciplina : Entity
    {
        public int IdTurma { get; set; }
        public Turma Turma { get; set; }
        public int IdDisciplina { get; set; }
        public Disciplina Disciplina { get; set; }
        public DateTime DataVinculacao { get; set; }
        public DateTime DataModificacao { get; set; }
        public Status Status { get; set; }
    }
}
