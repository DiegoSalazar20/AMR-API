using AMR.RN.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoHabitacionController : ControllerBase
    {
        private readonly ITipoHabitacionRN _tipoHabitacionRn;

        public TipoHabitacionController(ITipoHabitacionRN tipoHabitacionRn)
        {
            _tipoHabitacionRn = tipoHabitacionRn;
        }
        
        [HttpGet("ObtenerOfertas")]
        public async Task<IActionResult> ObtenerOfertas()
        {
            var informacion = await _tipoHabitacionRn.ObtenerTarifas();
            return Ok(informacion);
        }//ObtenerOfertas

        [HttpPut("ActualizarDatosHabitacion")]
        public async Task<IActionResult> ActualizarDatosHabitacion(string nombre, string descripcion, decimal tarifa, string imagen)
        {
            var resultado = await _tipoHabitacionRn.ActualizarDatosHabitacion(nombre, descripcion, tarifa, imagen);
            if (resultado)
            {
                return Ok("Los datos de la habitación se han actualizado correctamente.");
            }
            else
            {
                return BadRequest("No se pudo actualizar los datos de la habitación.");
            }
        }//ActualizarDatosHabitacion

    }//TipoHabitacionController
}
