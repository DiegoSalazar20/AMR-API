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

    }
}
