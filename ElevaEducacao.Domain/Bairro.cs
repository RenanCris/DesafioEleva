using ElevaEducacao.Domain.Core.Entities;
using System.Collections.Generic;

namespace ElevaEducacao.Domain
{
    public class Bairro : Entity
    {
        public string Descricao { get; set; }
        public ICollection<Endereco> Enderecos { get; set; }
    }
}
