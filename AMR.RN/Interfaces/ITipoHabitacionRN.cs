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
        public Task<TipoHabitacion> ObtenerDatosTipoHabitacion(int idTipoHabitacion);
        public Task<IEnumerable<TipoHabitacion>> ObtenerTarifas();
    }
}
