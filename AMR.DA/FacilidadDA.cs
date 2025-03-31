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
    public class FacilidadDA : IFacilidadesDA
    {

        private readonly ContextoBD _context;

        public FacilidadDA(ContextoBD context)
        {
            _context = context;
        }
        public async Task<bool> ActualizarInformacion(int idFacilidad, string nombre, string imagen, string descripcion)
        {
            var facilidadEntity = await _context.Facilidad.FirstOrDefaultAsync(f => f.Id == idFacilidad);

            if (facilidadEntity == null)
            {
                return false;
            }

            if (!string.IsNullOrWhiteSpace(nombre))
            {
                facilidadEntity.Nombre = nombre;
            }

            if (!string.IsNullOrWhiteSpace(imagen))
            {
                facilidadEntity.Imagen = imagen;
            }

            if (!string.IsNullOrWhiteSpace(descripcion))
            {
                facilidadEntity.Descripcion = descripcion;
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeshabilitarFacilidad(int idFacilidad)
        {
            var facilidadEntity = await _context.Facilidad.FirstOrDefaultAsync(f => f.Id == idFacilidad);

            if (facilidadEntity == null)
            {
                return false;
            }

            facilidadEntity.Estado = false; 
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> HabilitarFacilidad(int idFacilidad)
        {
            var facilidadEntity = await _context.Facilidad.FirstOrDefaultAsync(f => f.Id == idFacilidad);

            if (facilidadEntity == null)
            {
                return false;
            }

            facilidadEntity.Estado = true; 
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Facilidades>> ObtenerInformacion()
        {
            var facilidadesEntidad = await _context.Facilidad.ToListAsync();

            return facilidadesEntidad.Select(f => new Facilidades
            {
                Id = f.Id,
                Nombre = f.Nombre,
                Imagen = f.Imagen,
                Descripcion = f.Descripcion,
                Estado = f.Estado
            });
        }

        public async Task<IEnumerable<Facilidades>> ObtenerInformacionVisibles()
        {
            var publicidadEntidad = await _context.Facilidad.Where(p => p.Estado).ToListAsync();

            return publicidadEntidad.Select(f => new Facilidades 
            {
                Id = f.Id,
                Nombre = f.Nombre,
                Descripcion = f.Descripcion,
                Estado = f.Estado,
                Imagen=f.Imagen
            });
        }
    }


}
