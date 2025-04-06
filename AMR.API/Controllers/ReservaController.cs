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
        public async Task<IActionResult> RegistrarPublicidad(int idTipoHabitacion, string nombre, string apellido, string correo, string tarjeta, DateTime fechaLlegada, DateTime fechaSalida)
        {
            var resultado = await _reservaRN.RegistrarReserva(idTipoHabitacion, nombre, apellido, correo, tarjeta, fechaLlegada, fechaSalida);
            if (resultado.Item1)
                return Ok(new { success = true, codigoReserva = resultado.Item2 });
            else
                return BadRequest(new { success = false, message = resultado.Item2 });
        }

    }
}
