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

        [HttpPost]
        public async Task<IActionResult> RegistrarPublicidad(RegistroReserva reserva)
        {
            var resultado = await _reservaRN.RegistrarReserva(reserva.IdTipoHabitacion, reserva.Nombre, reserva.Apellidos, reserva.Correo, reserva.Tarjeta, reserva.FechaLlegada, reserva.FechaSalida);
            if (resultado.Item1)
                return Ok(new { success = true, codigoReserva = resultado.Item2 });
            else
                return BadRequest(new { success = false, message = resultado.Item2 });
        }

    }
}
