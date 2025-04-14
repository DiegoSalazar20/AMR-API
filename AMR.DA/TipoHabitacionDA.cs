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
    public class TipoHabitacionDA : ITipoHabitacionDA
    {
        private readonly ContextoBD _context;

        public TipoHabitacionDA(ContextoBD context)
        {
            _context = context;
        }

        public Task<bool> ActualizarDatosHabiacion(string nombre, string descripcion, decimal tarifa, string imagen)
        {
            throw new NotImplementedException();
        }

        public Task<TipoHabitacion> ObtenerDatosTipoHabitacion(int idTipoHabitacion)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TipoHabitacion>> ObtenerTarifas()
        {
            var tipoHabitacionesEntidad = await _context.TipoHabitacion.ToListAsync();
            var ofertasEntidad = await _context.Ofertas.ToListAsync();
            DateTime fechaActual = DateTime.Today;

            foreach (var tipoHabitacionEntidad in tipoHabitacionesEntidad)
            {
                tipoHabitacionEntidad.Precio +=
                    tipoHabitacionEntidad.Precio * ObtenerDescuentoTemporada(fechaActual).Result;
                foreach (var ofertaEntidad in ofertasEntidad)
                {
                    if (ofertaEntidad.IdTipoHabitacion == tipoHabitacionEntidad.IdTipoHabitacion &&
                        ofertaEntidad.Fecha_inicio < fechaActual && ofertaEntidad.Fecha_final > fechaActual)
                    {
                        tipoHabitacionEntidad.Precio -=
                            tipoHabitacionEntidad.Precio * ((decimal)ofertaEntidad.Descuento / 100);
                    }
                }
            } //foreach externo

            return tipoHabitacionesEntidad.Select(t => new TipoHabitacion
            {
                IdTipoHabitacion = t.IdTipoHabitacion,
                Nombre = t.Nombre,
                Descripcion = t.Descripcion,
                Precio = t.Precio,
                Imagen = t.Imagen
            });
        } //ObtenerTarifas

        private async Task<decimal> ObtenerDescuentoTemporada(DateTime fechaActual)
        {
            var temporadaEntidad = await _context.Temporada.FirstOrDefaultAsync(
                t => t.Fecha_inicio < fechaActual && t.Fecha_final > fechaActual
            );
            return temporadaEntidad != null ? ((decimal)temporadaEntidad.Descuento) / 100 : 0;
        } //obtenerDescuentoTemporada
    }
}