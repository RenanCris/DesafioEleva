using AutoMapper;
using ElevaEducacao.Domain;
using ElevaEducacao.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ElevaEducacao.Mapper
{
    public class AppProfile : ProfileBase
    {
        protected override void ApplyManualMapper()
        {
            EnderecoViewModelToModel();
        }

        private  void EnderecoViewModelToModel() {
            CreateMap<EnderecoEntradaViewModel, Endereco>()
                .ForMember(dest => dest.Cidade, m => m.MapFrom(x => x.IdCidade))
                .ForMember(dest => dest.Bairro, m => m.MapFrom(x => x.IdBairro));
        }

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
