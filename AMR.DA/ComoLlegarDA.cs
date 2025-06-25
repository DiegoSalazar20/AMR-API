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
    public class ComoLlegarDA : IComoLlegarDA
    {
        private readonly ContextoBD _context;

        public ComoLlegarDA(ContextoBD context)
        {
            _context = context;
        }

        public async Task<bool> ActualizarInformacion(ComoLlegar comollegar)
        {
            var homeEntity = await _context.ComoLlegar.FirstOrDefaultAsync();
            if (homeEntity == null)
            {
                return false;
            }

            homeEntity.Descripcion = comollegar.Descripcion;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ComoLlegar> ObtenerInformacion()
        {
            try
            {
                var comoLlegarEntidad = await _context.ComoLlegar.FirstOrDefaultAsync();

                if (comoLlegarEntidad == null)
                    return null;

                ComoLlegar datos = new ComoLlegar
                {
                    IdUbicacion = comoLlegarEntidad.IdUbicacion,
                    Descripcion = comoLlegarEntidad.Descripcion,
                    Latitud = comoLlegarEntidad.Latitud,
                    Longitud= comoLlegarEntidad.Longitud
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
