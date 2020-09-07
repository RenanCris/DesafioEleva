using ElevaEducacao.Domain.Core.Entities;
using System.Collections.Generic;

namespace ElevaEducacao.Domain
{
    public class UF : Entity {
        public string Descricao { get; set; }
        public ICollection<Cidade> Cidades { get; set; }
    }
}
