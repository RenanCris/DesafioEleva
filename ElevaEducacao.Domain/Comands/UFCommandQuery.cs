using ElevaEducacao.Domain.Core.Commands;
using ElevaEducacao.Domain.Core.Entities;
using ElevaEducacao.Domain.Core.Handlers;
using ElevaEducacao.Domain.Core.Interfaces;
using ElevaEducacao.Domain.Interfaces.Repository;
using ElevaEducacao.Infra.CrossCutting.MediatR;
using ElevaEducacao.Infra.CrossCutting.NotificationPattern;
using MediatR;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElevaEducacao.Domain.Comands
{
    public class UFCommandQuery : ICommandMapped<UF,int,List<UF>>
    {
        
    }

    public class UFCommandHandlerQuery : CommandHandlerBase<IUnitOfWork>, ICommandHandler<UFCommandQuery, List<UF>>
    {
        private readonly IUFRepository _uFRepository;
        public UFCommandHandlerQuery(INotificationContext notificationContext
            , IUnitOfWork uow
            , IUFRepository uFRepository) : base(notificationContext, uow)
        {
            _uFRepository = uFRepository;
        }

        public async Task<List<UF>> Handle(UFCommandQuery request, CancellationToken cancellationToken)
        {
            return await _uFRepository.ObterTodos();
        }
    }

    
}
