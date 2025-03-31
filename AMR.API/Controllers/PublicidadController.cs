using AMR.Dominio;
using AMR.RN;
using AMR.RN.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicidadController : ControllerBase
    {
        private readonly IPublicidadRN _publicidadRN;

        public PublicidadController(IPublicidadRN publicidadRN)
        {
            _publicidadRN = publicidadRN;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodasLasPublicidades()
        {
            var publicidades = await _publicidadRN.ObtenerTodasLasPublicidades();
            return Ok(publicidades);
        }

        [HttpGet("Visibles")]
        public async Task<IActionResult> ObtenerPublcidadesVisibles()
        {
            var publicidades = await _publicidadRN.ObtenerPublicidadVisible();
            return Ok(publicidades);
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarPublicidad(Publicidad publicidad)
        {
            var resultado = await _publicidadRN.RegistrarPublicidad(publicidad);
            if (resultado)
                return Ok(true);
            else
                return Ok(false);
        }

        [HttpPut("Habilitar")]
        public async Task<IActionResult> HabilitarPublicidad(int idPublicidad)
        {
            var resultado = await _publicidadRN.HabilitarPublicidad(idPublicidad);
            if (resultado)
                return Ok(true);
            else
                return Ok(false);
        }

        [HttpPut("Deshabilitar")]
        public async Task<IActionResult> DesabilitarPublicidad(int idPublicidad)
        {
            var resultado = await _publicidadRN.DeshabilitarPublicidad(idPublicidad);
            if (resultado)
                return Ok(true);
            else
                return Ok(false);
        }

        [HttpPut("Actualizar")]
        public async Task<IActionResult> ActualizarPublicidad(int idPublicidad, string nombre, string descripcion, string urlDestino, string urlImagen)
        {
            var resultado = await _publicidadRN.ActualizarInformacion(idPublicidad, nombre, descripcion, urlDestino, urlImagen);
            if (resultado)
                return Ok(true);
            else
                return Ok(false);
        }



    }
}
