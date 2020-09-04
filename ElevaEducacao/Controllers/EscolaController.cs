using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElevaEducacao.Controllers
{
    [Route("api/escola")]
    [ApiController]
    public class EscolaController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get() {
            return Ok("teste");
        }
    }
}