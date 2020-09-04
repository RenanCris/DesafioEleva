using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElevaEducacao.Domain.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> CommitAsync();
    }
}
