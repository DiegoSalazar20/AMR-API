using AMR.Dominio;
using AMR.RN;
using AMR.RN.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AMR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministradorController : ControllerBase
    {
        private readonly IAdministradorRN _administradorRN;
        private readonly IConfiguration _configuracion;

        public AdministradorController(IAdministradorRN administradorRN, IConfiguration configuracion)
        {
            _administradorRN = administradorRN;
            _configuracion = configuracion;
        }

        [HttpPost("login")]
        public async Task<IActionResult> InicioSesion([FromBody] LoginDTO login)
        {
            var admin = await _administradorRN.InicioSesion(login.NombreUsuario, login.Contrasena);
            if (admin == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, admin.IdAdministrador.ToString()),
                new Claim("nombre", admin.Nombre),
                new Claim("rol", "Administrador"),
                new Claim("estado", admin.Estado.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var llave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuracion["Jwt:Key"]));
            var credencial = new SigningCredentials(llave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuracion["Jwt:Issuer"],
                audience: null,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credencial
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                nombre = admin.Nombre,
                usuario = admin.NombreUsuario,
                estado = admin.Estado
            });
        }

        public class LoginDTO
        {
            public string NombreUsuario { get; set; }
            public string Contrasena { get; set; }
        }
    }
}
