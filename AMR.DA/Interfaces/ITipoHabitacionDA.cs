using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMR.Dominio;

namespace AMR.DA.Interfaces
{
    public interface ITipoHabitacionDA
    {
        public Task<bool> ActualizarDatosHabitacion(TipoHabitacion tipoHabitacion);
        public Task<IEnumerable<TipoHabitacion>> ObtenerDatosTiposHabitaciones();
        public Task<IEnumerable<TipoHabitacion>> ObtenerTarifas();
    }
}
