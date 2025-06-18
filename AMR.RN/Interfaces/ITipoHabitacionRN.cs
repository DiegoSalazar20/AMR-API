using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMR.Dominio;

namespace AMR.RN.Interfaces
{
    public interface ITipoHabitacionRN
    {
        public Task<bool> ActualizarDatosHabitacion(TipoHabitacion tipoHabitacion);
        public Task<IEnumerable<TipoHabitacion>> ObtenerDatosTiposHabitaciones();
        public Task<IEnumerable<TipoHabitacion>> ObtenerTarifas();
    }
}
