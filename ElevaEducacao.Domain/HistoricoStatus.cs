using ElevaEducacao.Domain.Core.Entities;
using System;

namespace ElevaEducacao.Domain
{
    public class HistoricoStatus : Entity {
        public int IdEscola { get; set; }
        public Escola Escola { get; set; }
        public Status Status { get; set; }
        public DateTime Data { get; set; }
    }
}
