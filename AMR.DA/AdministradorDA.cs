using AMR.DA.Contexto;
using AMR.DA.Interfaces;
using AMR.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMR.DA
{
    public class AdministradorDA : IAdministradorDA
    {
        private readonly ContextoBD _context;

        public AdministradorDA(ContextoBD context)
        {
            _context = context;
        }

        public async Task<Administrador> InicioSesion(string nombreUsuario, string contrasena)
        {
            var adminEntidad = await _context.Administrador
        .FirstOrDefaultAsync(a => a.NombreUsuario == nombreUsuario && a.Contrasena == contrasena && a.Estado);

            if (adminEntidad == null)
                return null;

            return new Administrador
            {
                IdAdministrador = adminEntidad.IdAdministrador,
                Nombre = adminEntidad.Nombre,
                Apellido = adminEntidad.Apellido,
                NombreUsuario = adminEntidad.NombreUsuario,
                Contrasena = adminEntidad.Contrasena,
                Estado = adminEntidad.Estado
            };
        }
    }
}
