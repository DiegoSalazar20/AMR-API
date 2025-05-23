using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMR.DA.Interfaces;
using AMR.Dominio;
using AMR.RN.Interfaces;

namespace AMR.RN
{
    public class TipoHabitacionRN : ITipoHabitacionRN
    {

        private readonly ITipoHabitacionDA _tipoHabitacionDA;

        public TipoHabitacionRN(ITipoHabitacionDA tipoHabitacionDA)
        {
            _tipoHabitacionDA = tipoHabitacionDA;
        }
        public async Task<bool> ActualizarDatosHabitacion(TipoHabitacion tipoHabitacion)
        {
            return await this._tipoHabitacionDA.ActualizarDatosHabitacion(tipoHabitacion);
        }

        public Task<TipoHabitacion> ObtenerDatosTipoHabitacion(int idTipoHabitacion)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TipoHabitacion>> ObtenerTarifas()
        {
            return await this._tipoHabitacionDA.ObtenerTarifas();
        }
    }
}
