using AutoMapper;
using ElevaEducacao.Domain.Core.Handlers;
using ElevaEducacao.Domain.Core.Interfaces;
using ElevaEducacao.Domain.Interfaces.Repository;
using ElevaEducacao.Infra.CrossCutting.NotificationPattern;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ElevaEducacao.Domain.Comands
{
    public class AlterarEscolaCommand : AdicionarEscolaCommand
    {
        public int Id { get; set; }
    }

    public class AlterarEscolaCommandHandler : CommandHandlerBase<IUnitOfWork>, ICommandHandler<AlterarEscolaCommand>
    {
        private readonly IEscolaRepository _repo;
        private readonly ICidadeRepository _repoCidade;
        private readonly IBairroRepository _repoBairro;
        private readonly IEnderecoRepository _repoEndereco;
        public AlterarEscolaCommandHandler(INotificationContext notificationContext
            , IUnitOfWork uow
            , IEscolaRepository repo
            , IMapper mapper
            , ICidadeRepository repoCidade
            , IBairroRepository repoBairro
            , IEnderecoRepository repoEndereco) : base(notificationContext, uow, mapper)
        {
            _repo = repo;
            _repoCidade = repoCidade;
            _repoBairro = repoBairro;
            _repoEndereco = repoEndereco;
        }

        public async Task<Unit> Handle(AlterarEscolaCommand request, CancellationToken cancellationToken)
        {
            var _escolaPorId = await _repo.ObterPorId(request.Id);
            var _escola = Mapper.Map(request, _escolaPorId);

            _escola.Endereco.Cidade = await _repoCidade.ObterPorId(_escola.Endereco.IdCidade);
            _escola.Endereco.Bairro = await _repoBairro.ObterPorId(_escola.Endereco.IdBairro);

            if (!IsValid<Escola>(_escola)) return Finish();

            if (await _repoEndereco.VerificarSeExisteEscolaNoEndereco(_escola.Endereco, _escola.Id))
                return Fail("Já existe outra escola nesse endereço!");

            foreach (var item in _escola.Telefones)
            {
                if (!IsValid<Telefone>(item)) return Finish();
            }

            await _repo.Atualizar(_escola);

            if (!IsValid<Endereco>(_escola.Endereco)) return Finish();

            await Commit();

            return Finish();
        }
    }


}
