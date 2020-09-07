using System.ComponentModel;

namespace ElevaEducacao.Domain
{
    public enum ModalidadesEnsino { 
        [Description("Fundamental")] FUNDAMENTAL = 1,
        [Description("Médio")] MEDIO = 2,
        [Description("Superior EAD")]  SUPERIOR_EAD = 3,
        [Description("Superior Presencial")] SUPERIOR_PRESENCIAL = 4
    }
}
