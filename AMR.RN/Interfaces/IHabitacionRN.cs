using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMR.DA.Entidades;

namespace AMR.RN.Interfaces
{
    public interface IHabitacionRN
    {
        public Task<string> ConsultarDisponibilidad(DateTime fechaInicio, DateTime fechaFin, int idTipoHabitacion);
        public Task<string> ConsultarHabitacionesDisponibles(DateTime fechaInicio, DateTime fechaFin, int idTipoHabitacion);
        public Task<string> VerEstadoHabitacionesHoy();
    }
}
