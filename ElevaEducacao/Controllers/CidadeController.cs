using System.Collections.Generic;
using System.Threading.Tasks;
using ElevaEducacao.Domain.Comands;
using ElevaEducacao.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ElevaEducacao.Controllers
{
    [Route("api/cidade")]
    [ApiController]
    public class CidadeController : ApiControllerBase
    {
        [HttpGet("todas")]
        public async Task<IActionResult> ObterTodas()
        {
            var _retorno = await Mediator.Send(new CidadeCommandQuery());
            return Ok(Mapper.Map<List<CidadeSaidaViewModel>>(_retorno));
        }
    }
}