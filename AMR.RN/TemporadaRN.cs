using AMR.DA.Interfaces;
using AMR.Dominio;
using AMR.RN.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMR.RN
{
    public class TemporadaRN : ITemporadaRN
    {
        private readonly ITemporadaDA _temporadaDA;

        public TemporadaRN(ITemporadaDA temporadaDA)
        {
            _temporadaDA = temporadaDA;
        }

        public async Task<bool> ActualizarTemporada(int idTemporada, string nombre_temporada, DateTime fecha_inicio, DateTime fecha_final, int descuento)
        {
            return await this._temporadaDA.ActualizarTemporada(idTemporada, nombre_temporada, fecha_inicio, fecha_final, descuento);
        }

        public async Task<bool> EliminarTemporada(int idTemporada)
        {
            return await this._temporadaDA.EliminarTemporada(idTemporada);
        }

        public async Task<IEnumerable<Temporada>> ObtenerTemporadas()
        {
            return await this._temporadaDA.ObtenerTemporadas();
        }

        public async Task<bool> RegistrarTemporada(Temporada temporada)
        {
            return await this._temporadaDA.RegistrarTemporada(temporada);
        }
    }
}
