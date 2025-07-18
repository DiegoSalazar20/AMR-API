﻿using AMR.Dominio;
using AMR.RN;
using AMR.RN.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComoLlegarController : ControllerBase
    {
        private readonly IComoLlegarRN _comoLlegarRN;

        public ComoLlegarController(IComoLlegarRN comoLlegarRN)
        {
            _comoLlegarRN = comoLlegarRN;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerInformacion()
        {

            var informacion = await _comoLlegarRN.ObtenerInformacion();
            return Ok(informacion);
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarInformacion(ComoLlegar comollegar)
        {
            var resultado = await _comoLlegarRN.ActualizarInformacion(comollegar);
            if (resultado)
                return Ok(true);
            else
                return Ok(false);
        }
    }
}
