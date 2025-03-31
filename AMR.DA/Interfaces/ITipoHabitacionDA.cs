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
        public Task<bool> ActualizarDatosHabiacion(string nombre, string descripcion, decimal tarifa, string imagen);
        public Task<TipoHabitacion> ObtenerDatosTipoHabitacion(int idTipoHabitacion);
        public Task<IEnumerable<TipoHabitacion>> ObtenerTarifas();
    }
}
