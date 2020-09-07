using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElevaEducacao.Domain.Comands;
using ElevaEducacao.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElevaEducacao.Controllers
{
    [Route("api/uf")]
    [ApiController]
    public class UFController : ApiControllerBase
    {
        [HttpGet("todas")]
        public async Task<IActionResult> ObterTodas()
        {
            var _retorno = await Mediator.Send(new UFCommandQuery());
            return Ok(Mapper.Map<List<UFSaidaViewModel>>(_retorno));
        }
    }
}