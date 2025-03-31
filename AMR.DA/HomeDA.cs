using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMR.DA.Contexto;
using AMR.DA.Interfaces;
using AMR.Dominio;
using Microsoft.EntityFrameworkCore;

namespace AMR.DA
{
    public class HomeDA : IHomeDA
    {

        private readonly ContextoBD _context;

        public HomeDA(ContextoBD context)
        {
            _context = context;
        }
        public async Task<bool> ActualizarInformacion(Home home)
        {
            {
                var homeEntity = await _context.Home.FirstOrDefaultAsync();
                if (homeEntity == null)
                {
                    return false; 
                }

                if (!string.IsNullOrWhiteSpace(home.Imagen))
                {
                    homeEntity.Imagen = home.Imagen;
                }

                homeEntity.Contenido = home.Contenido;

                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<Home> ObtenerInformacion()
        {
            try
            {
                var homeEntidad = await _context.Home.FirstOrDefaultAsync();

                if (homeEntidad == null)
                    return null;

                Home datos = new Home
                {
                    IdHome = homeEntidad.Id,
                    Imagen = homeEntidad.Imagen,
                    Contenido = homeEntidad.Contenido
                };

                return datos;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
