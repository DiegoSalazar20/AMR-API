using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMR.DA.Contexto;
using AMR.DA.Interfaces;
using AMR.Dominio;

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

        public Task<IEnumerable<TipoHabitacion>> ObtenerTarifas()
        {
            throw new NotImplementedException();
        }
    }
}
