using AMR.Dominio;
using AMR.RN.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemporadaController : ControllerBase
    {
        private readonly ITemporadaRN _temporadaRN;

        public TemporadaController (ITemporadaRN temporadaRN)
        {
            _temporadaRN = temporadaRN;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTemporadas()
        {
            var temporadas = await _temporadaRN.ObtenerTemporadas();
            return Ok(temporadas);
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarTemporada([FromBody] Temporada temporada)
        {

            var resultado = await _temporadaRN.RegistrarTemporada(temporada);
            if (resultado)
            {
                Ok(resultado);
            }

            return Ok(resultado);
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarTemporada([FromBody] Temporada temporada)
        {

            var resultado = await _temporadaRN.ActualizarTemporada(
                temporada.IdTemporada,
                temporada.Nombre_temporada,
                temporada.Fecha_inicio,
                temporada.Fecha_final,
                temporada.Descuento
            );

            if (!resultado)
                return NotFound(false);

            return Ok(true);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarTemporada(int id)
        {
            var resultado = await _temporadaRN.EliminarTemporada(id);

            if (!resultado)
                return NotFound(false);

            return Ok(true);
        }


    }
}
