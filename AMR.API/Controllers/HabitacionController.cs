using AMR.RN;
using AMR.RN.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitacionController : ControllerBase
    {
        private readonly IHabitacionRN _habitacionRN;

        public HabitacionController(IHabitacionRN habitacionRN)
        {
            _habitacionRN = habitacionRN;
        }

        [HttpGet("Disponibilidad")]
        public async Task<IActionResult> ConsultarDispoibilidad(DateTime fechainicio, DateTime fechafin, int idTipoHabitacion)
        {
            var informacion = await _habitacionRN.ConsultarDisponibilidad(fechainicio, fechafin, idTipoHabitacion);
            return Ok(informacion);
        }

        [HttpGet("HabitacionesDisponibles")]
        public async Task<IActionResult> ConsultarHabitacionesDisponibles(DateTime fechainicio, DateTime fechafin, int idTipoHabitacion)
        {
            var informacion = await _habitacionRN.ConsultarHabitacionesDisponibles(fechainicio, fechafin, idTipoHabitacion);
            return Ok(informacion);
        }

        [HttpGet("VerEstadoHabitacionesHoy")]
        public async Task<IActionResult> VerEstadoHabitacionesHoy()
        {
            var informacion = await _habitacionRN.VerEstadoHabitacionesHoy();
            return Ok(informacion);
        }

        [HttpPost("BloquearHabitacion")]
        public async Task<IActionResult> BloquearHabitacion([FromQuery] int idTipoHabitacion, [FromQuery] DateTime fechaLlegada, [FromQuery] DateTime fechaSalida)
        {
            var (success, idHabitacion, token, expiracion, message) = await this._habitacionRN.BloquearHabitacion(idTipoHabitacion, fechaLlegada, fechaSalida);

            if (!success)
                return BadRequest(new { success, message });

            return Ok(new
            {
                success,
                idHabitacion,
                token,
                expiracion,
                message
            });
        }

        [HttpPut("Habilitar")]
        public async Task<IActionResult> HabilitarHabitacion(int idHabitacion)
        {
            var resultado = await _habitacionRN.HabilitarHabitacion(idHabitacion);
            if (resultado)
                return Ok(true);
            else
                return Ok(false);
        }

        [HttpPut("Deshabilitar")]
        public async Task<IActionResult> DesabilitarHabitacion(int idHabitacion)
        {
            var resultado = await _habitacionRN.DeshabilitarHabitacion(idHabitacion);
            if (resultado)
                return Ok(true);
            else
                return Ok(false);
        }

    }
}
