using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMR.DA.Contexto;
using AMR.DA.Entidades;
using AMR.DA.Interfaces;
using AMR.Dominio;
using Microsoft.EntityFrameworkCore;

namespace AMR.DA
{
    public class PublicidadDA : IPublicidadDA
    {
        private readonly ContextoBD _context;

        public PublicidadDA(ContextoBD context)
        {
            _context = context;
        }

        public async Task<bool> ActualizarInformacion(int idPublicidad, string nombre, string descripcion, string urlDestino, string urlImagen)
        {
            var publicidadEntity = await _context.Publicidad.FirstOrDefaultAsync(p => p.Id == idPublicidad);

            if (publicidadEntity == null)
                return false;

            if (!string.IsNullOrWhiteSpace(nombre))
                publicidadEntity.Nombre = nombre;

            if (!string.IsNullOrWhiteSpace(descripcion))
                publicidadEntity.Descripcion = descripcion;

            if (!string.IsNullOrWhiteSpace(urlDestino))
                publicidadEntity.UrlDestino = urlDestino;

            if (!string.IsNullOrWhiteSpace(urlImagen))
                publicidadEntity.UrlImagen = urlImagen;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeshabilitarPublicidad(int idPublicidad)
        {
            var publicidadEntity = await _context.Publicidad.FirstOrDefaultAsync(p => p.Id == idPublicidad);

            if (publicidadEntity == null)
                return false;

            publicidadEntity.Visible = false;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> HabilitarPublicidad(int idPublicidad)
        {
            var publicidadEntity = await _context.Publicidad.FirstOrDefaultAsync(p => p.Id == idPublicidad);

            if (publicidadEntity == null)
                return false;

            publicidadEntity.Visible = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Publicidad>> ObtenerPublicidadVisible()
        {
            var publicidadEntidad = await _context.Publicidad.Where(p => p.Visible).ToListAsync();

            return publicidadEntidad.Select(f => new Publicidad
            {
                Id = f.Id,
                Nombre = f.Nombre,
                Descripcion = f.Descripcion,
                UrlDestino = f.UrlDestino,
                UrlImagen = f.UrlImagen,
                Visible = f.Visible
            });
        }

        public async Task<IEnumerable<Publicidad>> ObtenerTodasLasPublicidades()
        {
            var publicidadEntidad = await _context.Publicidad.ToListAsync();

            return publicidadEntidad.Select(f => new Publicidad
            {
                Id = f.Id,
                Nombre = f.Nombre,
                Descripcion = f.Descripcion,
                UrlDestino = f.UrlDestino,
                UrlImagen = f.UrlImagen,
                Visible= f.Visible
            });
        }

        public async Task<bool> RegistrarPublicidad(Publicidad publicidad)
        {
            if (publicidad == null)
                return false;

            PublicidadEntidad entidad = new PublicidadEntidad
            {
                Nombre=publicidad.Nombre,
                Descripcion=publicidad.Descripcion,
                UrlImagen=publicidad.UrlImagen,
                UrlDestino=publicidad.UrlDestino,
                Visible= publicidad.Visible
            };

            await _context.Publicidad.AddAsync(entidad);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
