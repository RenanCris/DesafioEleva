using ElevaEducacao.Infra.CrossCutting.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElevaEducacao.Helper
{
    public static class ObjetoEnum
    {
        public static Object ObterObjetoEnum<T>() where T : Enum {
            return ((T[])Enum.GetValues(typeof(T))).Select(x => new {
                Id = x,
                Descricao = x.GetDescription()
            }).OrderBy(z => z.Descricao);
        }
    }
}
