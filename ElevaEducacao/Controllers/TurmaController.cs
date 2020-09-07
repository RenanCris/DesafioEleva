using ElevaEducacao.Domain.Comands;
using ElevaEducacao.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElevaEducacao.Controllers
{
    [Route("api/turma")]
    [ApiController]
    public class TurmaController : ApiControllerBase
    {

        [HttpPost()]
        public async Task<IActionResult> Cadastrar([FromBody] TurmaEntradaViewModel turmaEntradaViewModel)
        {
            var _cmd = Mapper.Map<CadastrarTurmaCommand>(turmaEntradaViewModel);
            var _result = await Mediator.Send(_cmd);

            return Ok();
        }


        [HttpGet("Todas")]
        public async Task<IActionResult> ObterTodas()
        {
            var _result = await Mediator.Send(new ConsultarTurmasQuery());
            return Ok(Mapper.Map<List<TurmaSaidaViewModel>>(_result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var _result = await Mediator.Send(new ConsultarTurmasPorIdQuery() { Id = id });
            return Ok(Mapper.Map<TurmaSaidaViewModel>(_result));
        }

        [HttpGet("escola/{id}")]
        public async Task<IActionResult> ObterPorEscola(int id)
        {
            var _result = await Mediator.Send(new ConsultarTurmasPorEscolaQuery() { IdEscola = id });
            return Ok(Mapper.Map<List<TurmaSaidaViewModel>>(_result));
        }
    }
}
