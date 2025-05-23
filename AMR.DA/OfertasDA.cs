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
    public class OfertasDA: IOfertasDA
    {

        private readonly ContextoBD _context;

        public OfertasDA(ContextoBD context)
        {
            _context = context;
        }

        public async Task<bool> ActualizarOferta(int idOferta, string nombre_oferta, DateTime fecha_inicio, DateTime fecha_final, int descuento, int idTipoHabitacion)
        {
            var ofertaActualizada = await _context.Ofertas.FindAsync(idOferta);

            if (ofertaActualizada == null)
                return false;

            ofertaActualizada.Nombre_Oferta = nombre_oferta;
            ofertaActualizada.Fecha_inicio = fecha_inicio;
            ofertaActualizada.Fecha_final = fecha_final;
            ofertaActualizada.Descuento = descuento;
            ofertaActualizada.IdTipoHabitacion = idTipoHabitacion;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarOferta(int idOferta)
        {
            var oferta = await _context.Ofertas.FindAsync(idOferta);
            if (oferta == null)
                return false;

            _context.Ofertas.Remove(oferta);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Oferta>> ObtenerOfertas()
        {
            return await _context.Ofertas
               .Select(t => new Oferta
               {
                   IdOferta = t.IdOferta,
                   Nombre_Oferta = t.Nombre_Oferta,
                   Fecha_inicio = t.Fecha_inicio,
                   Fecha_final = t.Fecha_final,
                   Descuento = t.Descuento,
                   IdTipoHabitacion= t.IdTipoHabitacion
               }).ToListAsync();
        }

        public async Task<bool> RegistrarOferta(Oferta oferta)
        {
            try
            {
                var nuevaOferta = new OfertaEntidad
                {
                    Nombre_Oferta = oferta.Nombre_Oferta,
                    Fecha_inicio = oferta.Fecha_inicio,
                    Fecha_final = oferta.Fecha_final,
                    Descuento = oferta.Descuento,
                    IdTipoHabitacion= oferta.IdTipoHabitacion
                };

                _context.Ofertas.Add(nuevaOferta);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
