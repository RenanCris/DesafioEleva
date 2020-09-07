using ElevaEducacao.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ElevaEducacao.Mapper
{
    public class AppProfile : ProfileBase
    {
        protected override Assembly[] GetAssembliesForAutomation()
        {
            return new[]
            {
                typeof(Startup).Assembly,
                typeof(Escola).Assembly,
            };
        }
    }
}
