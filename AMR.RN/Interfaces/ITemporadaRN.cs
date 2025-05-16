using AMR.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMR.RN.Interfaces
{
    public interface ITemporadaRN
    {
        public Task<bool> ActualizarTemporada(int idTemporada, string nombre_temporada, DateTime fecha_inicio, DateTime fecha_final, int descuento);
        public Task<bool> EliminarTemporada(int idTemporada);
        public Task<IEnumerable<Temporada>> ObtenerTemporadas();
        public Task<bool> RegistrarTemporada(Temporada temporada);
    }
}
