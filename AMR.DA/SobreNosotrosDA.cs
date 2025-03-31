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
    public class SobreNosotrosDA : ISobreNosotrosDA
    {

        private readonly ContextoBD _context;

        public SobreNosotrosDA(ContextoBD context)
        {
            _context = context;
        }
        public async Task<bool> ActualizarInformacion(SobreNosotros sobreNosotros)
        {
            var sobrenosotrosEntidad = await _context.SobreNosotros.FirstOrDefaultAsync();
            if (sobrenosotrosEntidad == null)
            {
                return false;
            }

            sobrenosotrosEntidad.Texto = sobreNosotros.Texto;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<SobreNosotros> ObtenerInformacion()
        {
            try
            {
                var sobrenosotrosEntidad = await _context.SobreNosotros.FirstOrDefaultAsync();

                if (sobrenosotrosEntidad == null)
                    return null;

                SobreNosotros datos = new SobreNosotros
                {
                    Id = sobrenosotrosEntidad.Id,
                    Texto = sobrenosotrosEntidad.Texto
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
