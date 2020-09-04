using AutoMapper;
using System.Reflection;

namespace ElevaEducacao.Mapper
{
    public abstract class ProfileBase : Profile
    {
        protected ProfileBase()
        {
            Apply();
        }

        protected void Apply()
        {
            this.ApplyAutoMappings(GetAssembliesForAutomation());
        }

       
        protected abstract Assembly[] GetAssembliesForAutomation();
    }
}
