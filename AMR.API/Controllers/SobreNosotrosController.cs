using AMR.Dominio;
using AMR.RN;
using AMR.RN.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SobreNosotrosController : ControllerBase
    {
        private readonly ISobreNosotrosRN _sobrenosotrosRN;

        public SobreNosotrosController(ISobreNosotrosRN sobrenosotrosRN)
        {
            _sobrenosotrosRN = sobrenosotrosRN;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerInformacion()
        {

            var informacion = await _sobrenosotrosRN.ObtenerInformacion();
            return Ok(informacion);
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarInformacion(SobreNosotros sobreNosotros)
        {
            var resultado = await _sobrenosotrosRN.ActualizarInformacion(sobreNosotros);
            if (resultado)
                return Ok(true);
            else
                return Ok(false);
        }
    }
}
