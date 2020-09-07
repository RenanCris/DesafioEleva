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
    [Route("api/endereco")]
    [ApiController]
    public class EnderecoController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CadastrarEndereco([FromBody] EnderecoEntradaViewModel enderecoEntradaViewModel) {

            var _cmd = Mapper.Map<AdicionarEnderecoCommand>(enderecoEntradaViewModel);

            return Ok();
        }
    }
}