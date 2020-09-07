using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElevaEducacao.Domain;
using ElevaEducacao.Domain.Comands;
using ElevaEducacao.Helper;
using ElevaEducacao.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElevaEducacao.Controllers
{
    [Route("api/escola")]
    [ApiController]
    public class EscolaController : ApiControllerBase
    {
        [HttpGet("modalidades-ensino")]
        public IActionResult ObterModalidades() {
            return Ok(ObjetoEnum.ObterObjetoEnum<ModalidadesEnsino>());
        }

        [HttpGet("status")]
        public IActionResult ObterStatus()
        {
            return Ok(ObjetoEnum.ObterObjetoEnum<Status>());
        }

        [HttpGet("tipo-localizacao")]
        public IActionResult ObterTipoLocalizacao()
        {
            return Ok(ObjetoEnum.ObterObjetoEnum<TipoLocalizacao>());
        }

        [HttpGet("categoria-administrativa")]
        public IActionResult ObterCategoriaAdministrativa()
        {
            return Ok(ObjetoEnum.ObterObjetoEnum<CategoriaAdministrativa>());
        }

        [HttpGet("todas")]
        public async Task<IActionResult> ObterTodas()
        {
            var _result = await Mediator.Send(new EscolaCommandQuery());
            return Ok(Mapper.Map<List<EscolaSaidaViewModel>>(_result));
        }

        [HttpPost()]
        public async Task<IActionResult> CadastrarEscola([FromBody] EscolaEntradaViewModel escolaEntradaViewModel)
        {
            var _cmd = Mapper.Map<AdicionarEscolaCommand>(escolaEntradaViewModel);
            var _result = await Mediator.Send(_cmd);

            return Ok();
        }

        [HttpPut()]
        public async Task<IActionResult> AlterarEscola([FromBody] EscolaEntradaIdViewModel escolaEntradaIdViewModel)
        {
            var _cmd = Mapper.Map<AlterarEscolaCommand>(escolaEntradaIdViewModel);
            var _result = await Mediator.Send(_cmd);

            return Ok();
        }
    }
}