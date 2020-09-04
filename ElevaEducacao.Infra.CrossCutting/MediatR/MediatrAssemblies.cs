using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ElevaEducacao.Infra.CrossCutting.MediatR
{
    public class MediatrAssemblies
    {
        public readonly Assembly[] Assemblies;

        public MediatrAssemblies(Assembly[] assemblies)
        {
            Assemblies = assemblies;
        }
    }
}
