using AMR.RN.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactenosController : ControllerBase
    {
        private readonly IContactenosRN _contactenosRN;

        public ContactenosController(IContactenosRN contactenosRN)
        {
            _contactenosRN = contactenosRN;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerInformacion()
        {

            var informacion = await _contactenosRN.ObtenerInformacion();
            return Ok(informacion);
        }
    }
}
