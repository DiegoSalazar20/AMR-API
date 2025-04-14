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

    }//TipoHabitacionController
}
