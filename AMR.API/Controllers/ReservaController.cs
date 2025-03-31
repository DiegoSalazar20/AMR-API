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

    }
}
