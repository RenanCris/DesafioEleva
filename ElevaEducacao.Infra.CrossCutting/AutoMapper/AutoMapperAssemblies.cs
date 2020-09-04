using System.Reflection;

namespace ElevaEducacao.Infra.CrossCutting.AutoMapper
{
    public class AutoMapperAssemblies
    {
        public readonly Assembly[] Assemblies;

        public AutoMapperAssemblies(Assembly[] assemblies)
        {
            Assemblies = assemblies;
        }
    }
}
