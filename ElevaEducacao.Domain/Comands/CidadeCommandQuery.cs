using ElevaEducacao.Domain.Core.Commands;
using ElevaEducacao.Domain.Core.Handlers;
using ElevaEducacao.Domain.Core.Interfaces;
using ElevaEducacao.Domain.Interfaces.Repository;
using ElevaEducacao.Infra.CrossCutting.NotificationPattern;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ElevaEducacao.Domain.Comands
{
    public class CidadeCommandQuery : ICommandMapped<Cidade, int, List<Cidade>>
    {

    }
    public class CidadeCommandHandlerQuery : CommandHandlerBase<IUnitOfWork>, ICommandHandler<CidadeCommandQuery, List<Cidade>>
    {
        private readonly ICidadeRepository _repo;
        public CidadeCommandHandlerQuery(INotificationContext notificationContext
            , IUnitOfWork uow
            , ICidadeRepository repo) : base(notificationContext, uow)
        {
            _repo = repo;
        }

        public async Task<List<Cidade>> Handle(CidadeCommandQuery request, CancellationToken cancellationToken)
        {
            return await _repo.ObterTodos();
        }
    }
    
}
