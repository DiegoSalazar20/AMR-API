using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMR.DA.Contexto;
using AMR.DA.Entidades;
using AMR.DA.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AMR.DA
{
    public class HabitacionDA : IHabitacionDA
    {
        private readonly ContextoBD _context;

        public HabitacionDA(ContextoBD context)
        {
            _context = context;
        }


        public async Task<string> ConsultarDisponibilidad(DateTime fechaInicio, DateTime fechaFin, int idTipoHabitacion)
        {
            var tiposDisponibles = await ObtenerTiposDisponibles(fechaInicio, fechaFin, idTipoHabitacion);

            var ofertas = await ObtenerOfertas();
            var temporadas = await ObtenerTemporadas();

            var resultado = tiposDisponibles.Select(tipo => new
            {
                tipo.IdTipoHabitacion,
                tipo.Nombre,
                tipo.Descripcion,
                PrecioBase = tipo.Precio,
                tipo.Imagen,
                TotalAPagar = CalcularPrecioTotal(tipo, fechaInicio, fechaFin, ofertas, temporadas)
            });

            string json = JsonConvert.SerializeObject(resultado);
            return json;
        }

        private async Task<List<TipoHabitacionEntidad>> ObtenerTiposDisponibles(DateTime fechaInicio, DateTime fechaFin, int idTipoHabitacion)
        {
            var query = _context.Habitacion
                .Include(h => h.TipoHabitacion)
                .Where(h => h.Habilitada &&
                            (idTipoHabitacion == 0 || h.IdTipoHabitacion == idTipoHabitacion) &&
                            !_context.Reserva.Any(r => r.IdHabitacion == h.IdHabitacion &&
                                                        r.FechaLlegada < fechaFin &&
                                                        r.FechaSalida > fechaInicio));

            return await query.Select(h => h.TipoHabitacion).Distinct().ToListAsync();
        }

        private async Task<List<OfertaEntidad>> ObtenerOfertas()
        {
            return await _context.Ofertas.ToListAsync();
        }

        private async Task<List<TemporadaEntidad>> ObtenerTemporadas()
        {
            return await _context.Temporada.ToListAsync();
        }

        private decimal CalcularPrecioTotal(
            TipoHabitacionEntidad tipo,
            DateTime fechaInicio,
            DateTime fechaFin,
            List<OfertaEntidad> ofertas,
            List<TemporadaEntidad> temporadas)
        {
            decimal total = 0;
            for (DateTime dia = fechaInicio.Date; dia < fechaFin.Date; dia = dia.AddDays(1))
            {
                decimal precioBase = tipo.Precio;
                decimal precioConTemporada = precioBase;

                var temporada = temporadas.FirstOrDefault(t =>
                    ValidarFechasSinAnio(dia, t.Fecha_inicio, t.Fecha_final));
                if (temporada != null)
                {
                    precioConTemporada = precioBase + (precioBase * temporada.Descuento / 100m);
                }

                decimal precioFinal = precioConTemporada;
                var oferta = ofertas.FirstOrDefault(o =>
                    o.IdTipoHabitacion == tipo.IdTipoHabitacion &&
                    dia >= o.Fecha_inicio.Date && dia <= o.Fecha_final.Date);
                if (oferta != null)
                {
                    precioFinal = precioConTemporada - (precioConTemporada * oferta.Descuento / 100m);
                }
                total += precioFinal;
            }
            return total;
        }
        private bool ValidarFechasSinAnio(DateTime dia, DateTime inicioFecha, DateTime finFecha)
        {
            DateTime normalizedDia = new DateTime(2000, dia.Month, dia.Day);
            DateTime normalizedInicio = new DateTime(2000, inicioFecha.Month, inicioFecha.Day);
            DateTime normalizedFin = new DateTime(2000, finFecha.Month, finFecha.Day);

            if (normalizedInicio <= normalizedFin)
            {
                return normalizedDia >= normalizedInicio && normalizedDia <= normalizedFin;
            }
            else
            {
                return normalizedDia >= normalizedInicio || normalizedDia <= normalizedFin;
            }
        }




    }
}
