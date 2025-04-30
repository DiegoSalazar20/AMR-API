using AMR.Dominio;
using AMR.RN;
using AMR.RN.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministradorController : ControllerBase
    {
        private readonly IAdministradorRN _administradorRN;

        public AdministradorController(IAdministradorRN administradorRN)
        {
            _administradorRN = administradorRN;
        }

        [HttpGet]
        public async Task<IActionResult> InicioSesion(string nombreUsuario, string contrasena)
        {
            var informacion = await _administradorRN.InicioSesion(nombreUsuario, contrasena);

            if (informacion == null)
                return Ok(Array.Empty<Administrador>());

            return Ok(new[] { informacion });
        }
    }
}
