using AutoMapper;
using ElevaEducacao.Domain.Core.Commands;
using ElevaEducacao.Domain.Core.Handlers;
using ElevaEducacao.Domain.Core.Interfaces;
using ElevaEducacao.Domain.Interfaces.Repository;
using ElevaEducacao.Infra.CrossCutting.NotificationPattern;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ElevaEducacao.Domain.Comands
{
    public class AdicionarEscolaCommand : ICommandMapped<Escola> {

        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
        public bool ConvenioPoderPublico { get; set; }
        public bool AtendeEducacaoEspecial { get; set; }
        public List<Telefone> Telefones { get; set; }
        public List<Modalidade> Modalidades { get; set; }
        public CategoriaAdministrativa CategoriaAdministrativa { get; set; }
        public TipoLocalizacao TipoLocalizacao { get; set; }
    }

    public class AdicionarEscolaCommandHandler : CommandHandlerBase<IUnitOfWork>, ICommandHandler<AdicionarEscolaCommand>
    {
        private readonly IEscolaRepository _repo;
        private readonly ICidadeRepository _repoCidade;
        private readonly IBairroRepository _repoBairro;
        private readonly IEnderecoRepository _repoEndereco;
        public AdicionarEscolaCommandHandler(INotificationContext notificationContext
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

        public async Task<Unit> Handle(AdicionarEscolaCommand request, CancellationToken cancellationToken)
        {
            var _escola = Mapper.Map<Escola>(request);

            _escola.Endereco.Cidade = await _repoCidade.ObterPorId(_escola.Endereco.IdCidade);
            _escola.Endereco.Bairro = await _repoBairro.ObterPorId(_escola.Endereco.IdBairro);

            if (!IsValid<Escola>(_escola)) return Finish();

            if (await _repoEndereco.VerificarSeExisteEscolaNoEndereco(_escola.Endereco))
                return Fail("Já existe escola nesse endereço!");

            foreach (var item in _escola.Telefones)
            {
                if (!IsValid<Telefone>(item)) return Finish();
            }

            await _repo.Criar(_escola);

            if (!IsValid<Endereco>(_escola.Endereco)) return Finish();

            await Commit();

            return Finish();
        }
    }


}
