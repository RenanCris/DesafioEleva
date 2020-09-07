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
    }
}
