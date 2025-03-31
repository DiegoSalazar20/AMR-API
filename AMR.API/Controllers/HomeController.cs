using AMR.Dominio;
using AMR.RN.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHomeRN _homeRN;

        public HomeController(IHomeRN homeRN)
        {
            _homeRN = homeRN;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerInformacion()
        {

            var informacion = await _homeRN.ObtenerInformacion();
            return Ok(informacion);
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarInformacion(Home home)
        {
            var resultado = await _homeRN.ActualizarInformacion(home);
            if (resultado)
                return Ok(true);
            else
                return Ok(false);
        }


    }
}
