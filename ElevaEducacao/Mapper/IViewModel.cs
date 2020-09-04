using ElevaEducacao.Infra.CrossCutting.AutoMapper;
using System.Threading.Tasks;

namespace ElevaEducacao.Mapper
{
    public interface IViewModel<T> : IMapFrom<T>
        where T : class
    {

    }
}
