using AMR.Dominio;
using AMR.RN;
using AMR.RN.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfertasController : ControllerBase
    {
        private readonly IOfertasRN _ofertasRN;

        public OfertasController(IOfertasRN ofertasRN)
        {
            _ofertasRN = ofertasRN;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerOfertas()
        {
            var ofertas = await _ofertasRN.ObtenerOfertas();
            return Ok(ofertas);
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarOfertas([FromBody] Oferta oferta)
        {

            var resultado = await _ofertasRN.RegistrarOferta(oferta);
            if (resultado)
            {
                Ok(resultado);
            }

            return Ok(resultado);
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarOfertas([FromBody] Oferta oferta)
        {

            var resultado = await _ofertasRN.ActualizarOferta(
                oferta.IdOferta,
                oferta.Nombre_Oferta,
                oferta.Fecha_inicio,
                oferta.Fecha_final,
                oferta.Descuento,
                oferta.IdTipoHabitacion
            );

            if (!resultado)
                return NotFound(false);

            return Ok(true);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarOferta(int id)
        {
            var resultado = await _ofertasRN.EliminarOferta(id);

            if (!resultado)
                return NotFound(false);

            return Ok(true);
        }

    }
}
