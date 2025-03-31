using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMR.DA.Contexto;
using AMR.DA.Entidades;
using AMR.DA.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AMR.DA
{
    public class HabitacionDA : IHabitacionDA
    {
        private readonly ContextoBD _context;

        public HabitacionDA(ContextoBD context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TipoHabitacionEntidad>> ConsultarDisponibilidad(DateTime fechaInicio, DateTime fechaFin, int idTipoHabitacion)
        {
            var habitacionesDisponibles = _context.Habitacion
                .Include(h => h.TipoHabitacion)
                .Where(h => h.Habilitada
                    && (idTipoHabitacion == 0 || h.IdTipoHabitacion == idTipoHabitacion)
                    && !_context.Reserva.Any(r => r.IdHabitacion == h.IdHabitacion
                        && r.FechaLlegada < fechaFin
                        && r.FechaSalida > fechaInicio));

            var tiposDisponibles = await habitacionesDisponibles
                .Select(h => h.TipoHabitacion)
                .Distinct()
                .ToListAsync();

            return tiposDisponibles;
        }
    }
}
