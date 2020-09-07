using ElevaEducacao.Domain.Core.Entities;
using System.Collections.Generic;

namespace ElevaEducacao.Domain
{
    public class Cidade : Entity
    {
        public UF UF { get; set; }
        public string Descricao { get; set; }
        public ICollection<Endereco> Enderecos { get; set; }
    }
}
