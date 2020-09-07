using ElevaEducacao.Domain.Core.Entities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ElevaEducacao.Domain
{
    public class Escola : Entity
    {
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
        public bool ConvenioPoderPublico { get; set; }
        public bool AtendeEducacaoEspecial { get; set; }
        public List<Telefone> Telefones { get; set; }
        public List<HistoricoStatus> StatusHistorico { get; set; }
        public List<Modalidade> Modalidades { get; set; }
        public CategoriaAdministrativa CategoriaAdministrativa { get; set; }
        public TipoLocalizacao TipoLocalizacao { get; set; }
        public List<Turma> Turmas { get; set; }

        public Escola()
        {
           
        }
    }

    
}
