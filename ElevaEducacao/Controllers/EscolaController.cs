using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElevaEducacao.Domain;
using ElevaEducacao.Helper;
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
    }
}