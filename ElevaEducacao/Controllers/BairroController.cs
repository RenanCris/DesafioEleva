using System.Collections.Generic;
using System.Threading.Tasks;
using ElevaEducacao.Domain.Comands;
using ElevaEducacao.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ElevaEducacao.Controllers
{
    [Route("api/bairro")]
    [ApiController]
    public class BairroController : ApiControllerBase
    {
        [HttpGet("todas")]
        public async Task<IActionResult> ObterTodas()
        {
            var _retorno = await Mediator.Send(new BairroCommandQuery());
            return Ok(Mapper.Map<List<BairroSaidaViewModel>>(_retorno));
        }
    }
}