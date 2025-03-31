using AMR.Dominio;
using AMR.RN;
using AMR.RN.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilidadesController : ControllerBase
    {
        private readonly IFacilidadesRN _facilidadRN;

        public FacilidadesController(IFacilidadesRN facilidadRN)
        {
            _facilidadRN = facilidadRN;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerInformacion()
        {

            var informacion = await _facilidadRN.ObtenerInformacion();
            return Ok(informacion);
        }

        [HttpGet("Visibles")]
        public async Task<IActionResult> ObtenerInformacionVisibles()
        {
            var informacion = await _facilidadRN.ObtenerInformacionVisibles();
            return Ok(informacion);
        }

        [HttpPut("Habilitar")]
        public async Task<IActionResult> HabilitarFacilidad(int idFacilidad)
        {
            var resultado = await _facilidadRN.HabilitarFacilidad(idFacilidad);
            if (resultado)
                return Ok(true);
            else
                return Ok(false);
        }

        [HttpPut("Deshabilitar")]
        public async Task<IActionResult> DeshabilitarFacilidad(int idFacilidad)
        {
            var resultado = await _facilidadRN.DeshabilitarFacilidad(idFacilidad);
            if (resultado)
                return Ok(true);
            else
                return Ok(false);
        }

        [HttpPut("Actualizar")]
        public async Task<IActionResult> ActualizarFacilidad(int idFacilidad, string nombre, string imagen, string descripcion)
        {
            var resultado = await _facilidadRN.ActualizarInformacion(idFacilidad, nombre, imagen, descripcion);
            if (resultado)
                return Ok(true);
            else
                return Ok(false);
        }


    }
}
