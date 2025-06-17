using AMR.Dominio;
using AMR.RN;
using AMR.RN.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {

        private readonly IReservaRN _reservaRN;

        public ReservaController(IReservaRN reservaRN)
        {
            _reservaRN = reservaRN;
        }

        [HttpGet()]
        public async Task<IActionResult> ConsultarDispoibilidad()
        {
            var informacion = await _reservaRN.ObtenerTodasLasReservas();
            return Ok(informacion);
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarPublicidad(RegistroReserva reserva)
        {
            var resultado = await _reservaRN.RegistrarReserva(reserva.IdHabitacion, reserva.BloqueoToken, reserva.Nombre, reserva.Apellidos, reserva.Correo, reserva.Tarjeta, reserva.FechaLlegada, reserva.FechaSalida);
            if (resultado.Item1)
                return Ok(new { success = true, codigoReserva = resultado.Item2 });
            else
                return BadRequest(new { success = false, message = resultado.Item2 });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarReserva(int id)
        {
            var resultado = await _reservaRN.EliminarReserva(id);

            if (!resultado)
                return NotFound(new { mensaje = "No se encontró la reserva o no se pudo eliminar." });

            return Ok(resultado);
        }

    }
}
