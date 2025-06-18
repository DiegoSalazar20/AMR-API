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
            var ahora = DateTime.UtcNow;

            var query = _context.Habitacion
                .Include(h => h.TipoHabitacion)
                .Where(h =>
                    h.Habilitada
                    && (idTipoHabitacion == 0 || h.IdTipoHabitacion == idTipoHabitacion)
                    && !_context.Reserva.Any(r =>
                        r.IdHabitacion == h.IdHabitacion &&
                        r.FechaLlegada < fechaFin &&
                        r.FechaSalida > fechaInicio)
                    && !_context.HabitacionesPorReservar.Any(ho =>
                        ho.IdHabitacion == h.IdHabitacion &&
                        ho.Expiracion > ahora)
                );

            return await query
                .Select(h => h.TipoHabitacion)
                .Distinct()
                .ToListAsync();
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

        public async Task<string> ConsultarHabitacionesDisponibles(DateTime fechaInicio, DateTime fechaFin, int idTipoHabitacion)
        {
            var habitacionesDisponibles = await _context.Habitacion
        .Include(h => h.TipoHabitacion)
        .Where(h =>
            h.Habilitada &&
            (idTipoHabitacion == 0 || h.IdTipoHabitacion == idTipoHabitacion) &&
            !_context.Reserva.Any(r =>
                r.IdHabitacion == h.IdHabitacion &&
                r.FechaLlegada < fechaFin &&
                r.FechaSalida > fechaInicio))
        .ToListAsync();

            var ofertas = await ObtenerOfertas();
            var temporadas = await ObtenerTemporadas();

            var resultado = habitacionesDisponibles.Select(h => new
            {
                NumeroHabitacion = h.NumeroHabitacion,
                TipoHabitacion = h.TipoHabitacion.Nombre,
                Precio = CalcularPrecioTotal(
                                       h.TipoHabitacion,
                                       fechaInicio,
                                       fechaFin,
                                       ofertas,
                                       temporadas)
            });

            return JsonConvert.SerializeObject(resultado);
        }

        public async Task<string> VerEstadoHabitacionesHoy()
        {
            DateTime hoy = DateTime.Today;

            
            var habitaciones = await _context.Habitacion
                .Include(h => h.TipoHabitacion)
                .ToListAsync();

            var reservasHoy = await _context.Reserva
                .Where(r =>
                    
                    r.FechaLlegada.Date == hoy
                  
                    || (r.FechaLlegada.Date < hoy && r.FechaSalida.Date > hoy))
                .ToListAsync();

            
            var resultado = habitaciones.Select(h =>
            {
                string estado;

                if (!h.Habilitada)
                {
                    estado = "Deshabilitada";
                }
                else if (reservasHoy.Any(r => r.IdHabitacion == h.IdHabitacion && r.FechaLlegada.Date == hoy))
                {
                    estado = "Reservada";
                }
                else if (reservasHoy.Any(r => r.IdHabitacion == h.IdHabitacion && r.FechaLlegada.Date < hoy && r.FechaSalida.Date > hoy))
                {
                    estado = "Ocupada";
                }
                else
                {
                    estado = "Disponible";
                }

                return new
                {
                    NumeroHabitacion = h.NumeroHabitacion,
                    TipoHabitacion = h.TipoHabitacion.Nombre,
                    Estado = estado,
                    IdTipoHabitacion= h.IdTipoHabitacion
                };
            });

            return JsonConvert.SerializeObject(resultado);
        }

        public async Task<(bool Exito, int IdHabitacion, string Token, DateTime Expiracion, string Message)> BloquearHabitacion(int idTipoHabitacion, DateTime fechaLlegada, DateTime fechaSalida)
        {
             TimeSpan DuracionBloqueo = TimeSpan.FromMinutes(5);
        var ahora = DateTime.UtcNow;

            var habitacion = await _context.Habitacion
                .Where(h =>
                    h.Habilitada &&
                    h.IdTipoHabitacion == idTipoHabitacion &&

                    !_context.Reserva.Any(r =>
                        r.IdHabitacion == h.IdHabitacion &&
                        r.FechaLlegada < fechaSalida &&
                        r.FechaSalida > fechaLlegada) &&

                    !_context.HabitacionesPorReservar.Any(ho =>
                        ho.IdHabitacion == h.IdHabitacion &&
                        ho.Expiracion > ahora)
                )
                .FirstOrDefaultAsync();

            if (habitacion == null)
            {
                return (false, 0, null!, default,
                        "No hay habitaciones disponibles (o todas están ya bloqueadas).");
            }

            var token = Guid.NewGuid().ToString("N");
            var expiracion = ahora.Add(DuracionBloqueo);

            var hold = new HabitacionesPorReservarEntidad
            {
                IdHabitacion = habitacion.IdHabitacion,
                Token = token,
                Expiracion = expiracion
            };
            _context.HabitacionesPorReservar.Add(hold);
            await _context.SaveChangesAsync();

            return (true,
                    habitacion.IdHabitacion,
                    token,
                    expiracion,
                    "Hold creado correctamente.");
        }

        public async Task<bool> HabilitarHabitacion(int idHabitacion)
        {
            string numero = idHabitacion + "";
            var habitacion = await _context.Habitacion
                .FirstOrDefaultAsync(h => h.NumeroHabitacion == numero);

            if (habitacion == null)
                return false;

            if (habitacion.Habilitada)
                return true;

            habitacion.Habilitada = true;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeshabilitarHabitacion(int idHabitacion)
        {
            var hoy = DateTime.Today;
            string numero = idHabitacion + "";

            var habitacion = await _context.Habitacion
                .FirstOrDefaultAsync(h => h.NumeroHabitacion == numero);

            if (habitacion == null)
                return false;

            bool tieneReservas = await _context.Reserva
                .AnyAsync(r =>
                    r.IdHabitacion == idHabitacion &&
                    r.FechaSalida > hoy);

            if (tieneReservas)
                return false;

            habitacion.Habilitada = false;
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
